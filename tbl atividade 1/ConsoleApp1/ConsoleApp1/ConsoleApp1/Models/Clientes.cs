using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models.Clientes
{
    internal class Cliente
    {
        public string nome;
        public int id_cliente;
        public string email;

        public Cliente(int id, string name, string mail) {
            this.id_cliente = id;
            this.nome = name;
            this.email = mail;
        }

        public void show()
        {
            Console.WriteLine("Dados do cliente: " + this.id_cliente);
            Console.WriteLine(this.nome);
            Console.WriteLine(this.email);
        }
    }
}
