using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vendas.Models
{
    public class Entrega
    {
        public string NumPedido { get; set; }
        public string Telefone { get; set; }
        public string PrevisaoEntrega { get; set; }
        public string CodCliente { get; set; }
        public string CodCaminhao { get; set; }
        public string StatusEntrega { get; set; }
        public string NumParcial { get; set; }
        public string Observacao { get; set; }
        public string FormaPagamento { get; set; }
        public string ValorEntrega { get; set; }
        public string Endereco { get; set; }
    }
}