using ApiPessoa.API.Configuracao;
using ApiPessoa.IoC;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ApiPessoa.Testes.Unidade
{
    [Trait("TestCategory", "Unidade")]
    [Trait("Category", "Unidade")]
    [Collection(TesteUnidadeCollection.Nome)]
    public abstract class TesteUnidade
    {
        protected readonly IConfiguration Configuration;

        protected TesteUnidade() =>
            Configuration = ConfiguracaoFabrica.Criar();
    }

    [CollectionDefinition(Nome)]
    public class TesteUnidadeCollection : ICollectionFixture<TesteUnidadeBase>
    {
        public const string Nome = "TesteUnidadeCollection";
    }

    public class TesteUnidadeBase
    {
        public TesteUnidadeBase() =>
            PerfilMapeamento.Criar();
    }
}
