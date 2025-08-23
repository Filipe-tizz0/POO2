using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models.Clientes;

namespace ConsoleApp1.Models.Pedido
{
    internal class Pedido
    {
        public int id_pedido;
        public string nome_produto;
        public Cliente cliente;

        public Pedido(int id, string nome, Cliente cliente) {
            this.id_pedido = id;
            this.nome_produto = nome;
            this.cliente = cliente;
        }

        public void show()
        {
            Console.WriteLine("Dados do pedido:" + this.id_pedido);
            Console.WriteLine(this.nome_produto);
            Console.WriteLine("Nome do cliente associado ao pedido: " + this.cliente.nome);
        }
    }
}
