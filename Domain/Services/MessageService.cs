using ApiCadFilmes.Domain.Models.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Services
{
    public class MessageService : IMessageService
    {
        public string MsgPreencherCampoVazioObrigatorio(string nomeCampo)
        {
            var msgPreencherCampoVazioObrigatorio = $"Campo {nomeCampo} é obrigatório e deve ser preenchido.";
            return msgPreencherCampoVazioObrigatorio;
        }

        public string MsgTamanhoMinEMaxDoCampo(string nomeCampo)
        {
            var msgTamanhoMinEMaxDoCampo = $"Campo {nomeCampo}  deve ter no mínimo" + " {MinLength} e no máximo {MaxLength} caracteres.";
            return msgTamanhoMinEMaxDoCampo;
        }

        public string MsgBooleanoNaoPodeSerNulo(string nomeCampo)
        {
            var msgBooleanoNaoPodeSerNulo = $"O campo {nomeCampo} não pode ser nulo, deve ser true ou false";
            return msgBooleanoNaoPodeSerNulo;
        }
    }
}
