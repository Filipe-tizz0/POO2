using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atv2Tbl.Models.Produto
{
    internal class Produtos
    {
        public string nome;
        public double preco;

        public Produtos(string name, double preco)
        {
            this.nome = name;
            this.preco = preco;
        }
    }
}
