using ApiPessoa.API.Configuracao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using System;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using ApiPessoa.API.Middleware.Erro;
using ApiPessoa.IoC;
using Microsoft.EntityFrameworkCore;
using ApiPessoa.Repositorio.Contexto;

namespace ApiPessoa
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) =>
            Configuration = ConfiguracaoFabrica.Criar(env);

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region MVC
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(options => {
                        options.SerializerSettings.DateFormatString = "dd/MM/yyyy";
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });
            #endregion

            #region Versionamento
            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'V");
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
            });
            #endregion

            services.AddCors();

            #region Documentação (Swagger)
            services.AddSwaggerGen(c =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                    c.SwaggerDoc(description.GroupName, new Info() { Title = $"API Pessoa", Version = description.ApiVersion.ToString() });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                c.DescribeAllEnumsAsStrings();

                var arquivoXml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var caminhoXml = Path.Combine(AppContext.BaseDirectory, arquivoXml);
                c.IncludeXmlComments(caminhoXml);
                c.CustomSchemaIds(x => x.FullName);
                c.DescribeAllParametersInCamelCase();

                //c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Name = "Authorization", Type = "apiKey" });
                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() } });
            });
            #endregion

            #region Pessoa Contexto (Base de dados)                        
            services.AddDbContext<ApiPessoaContexto>(opcoes => opcoes
                .UseInMemoryDatabase("ApiPessoa.BaseDeDados")
                .EnableSensitiveDataLogging());

#if DEBUG
            services.AddDbContext<ApiPessoaContexto>(opcoes => opcoes
                .UseSqlServer(Configuration.GetConnectionString("ApiPessoaContexto"))
                .UseInMemoryDatabase("ApiPessoa.BaseDeDados")
                .EnableSensitiveDataLogging());

            // Get the database context and apply the migrations
            var context = services.BuildServiceProvider().GetService<ApiPessoaContexto>();
            context.Database.Migrate();
#endif

            #endregion

            services.AddInjecaoDependencia(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

#region Documentação (Swagger)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            app.UseReDoc(c =>
            {
                c.DocumentTitle = "API Pessoa";
                c.SpecUrl = $"{Configuration["Aplicacao:Nome"]}/swagger/v1/swagger.json";
            });
#endregion (Swagger)


#region cultura
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
#endregion

            app.UseErro();
            app.UseMvc();
        }
    }
}
