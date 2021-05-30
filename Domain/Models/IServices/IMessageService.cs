using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.IServices
{
    public interface IMessageService
    {
        public string MsgPreencherCampoVazioObrigatorio(string nomeCampo);

        public string MsgTamanhoMinEMaxDoCampo(string nomeCampo);

        public string MsgBooleanoNaoPodeSerNulo(string nomeCampo);
    }
}
