// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Models.Clientes;
using ConsoleApp1.Models.Pedido;

Console.WriteLine("Digite seu nome, email e nome do produto a ser commprado:");
Cliente cliente = new Cliente(1, Console.ReadLine(), Console.ReadLine());
Pedido pedido = new Pedido(12, Console.ReadLine(), cliente);

cliente.show();
pedido.show();