using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atv2Tbl.Models.Produto;

namespace Atv2Tbl.Models.Carrinho
{
    internal class Carrinho
    {
        public List <Produtos> produto;
        private double total;
        public string forma_pagamento;

        public Carrinho(List<Produtos> produtos, string form_pagamento) 
        {
            this.produto = produtos;
            this.forma_pagamento = form_pagamento;
            foreach (Produtos produto in produto)
            {
                this.total += produto.preco;
            }
            Console.WriteLine($"O valor Total do Carrinho é: {this.total}");
        }

        public void apresentar_produtos ()
        {
            Console.WriteLine("\nNome e preço dos produtos:");
            foreach (Produtos p in produto)
            {
                Console.WriteLine($" - {p.nome} : {p.preco}");
            }
            Console.WriteLine($"\nForma de pagamento:\n - {this.forma_pagamento}");
        }
    }
}
