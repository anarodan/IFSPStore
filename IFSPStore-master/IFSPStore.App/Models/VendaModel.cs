using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.App.Models
{
    public class VendaModel
    {
        public VendaModel()
        {
            Items = new List<VendaItemModel>();
        }
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public List<VendaItemModel> Items { get; set; }
    }

    public class VendaItemModel
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string? Produto { get; set; }
        public float ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public float ValorTotal { get; set; }
    }
}
