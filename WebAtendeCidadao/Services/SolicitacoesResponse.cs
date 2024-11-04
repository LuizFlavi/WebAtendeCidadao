using System.Collections.Generic;
using WebAtendeCidadao.Models;

namespace WebAtendeCidadao.Services
{
    public class SolicitacoesResponseWrapper
    {
        public ItemsContainer Items { get; set; }

        public class ItemsContainer
        {
            public List<SolicitacaoModel> values { get; set; }
        }
    }
}





