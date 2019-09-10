using ApiPessoa.Aplicacao.CasosDeUso.Pessoas;
using ApiPessoa.Aplicacao.CasosDeUso.Pessoas.CadastrarPessoas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiPessoa.CasosDeUso.Pessoas
{
    public class PessoaDtoPerfil : Profile
    {
        public PessoaDtoPerfil()
        {
            CreateMap<PessoaDto, PessoaView>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.Sexo));
        }
    }
}
