using ApiPessoa.Aplicacao.CasosDeUso.Pessoas;
using ApiPessoa.Dominio.Comum.Extensao;
using ApiPessoa.Dominio.Pessoas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.CasosDeUso.Pessoas
{
    public class PessoaPerfil : Profile
    {
        public PessoaPerfil()
        {
            CreateMap<Pessoa, PessoaView>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo.ObterDescricao()))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf));
        }
    }
}
