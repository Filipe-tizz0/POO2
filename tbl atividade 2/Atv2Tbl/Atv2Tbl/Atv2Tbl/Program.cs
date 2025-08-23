using Atv2Tbl.Models.Produto;
using Atv2Tbl.Models.Carrinho;
using System.Collections.Generic;

List<Produtos> product_list = new List<Produtos>();

for (int i = 0; i < 5;)
{
    Console.WriteLine("Digite o nome do produto e sem seguida o preço:");
    Produtos produto = new Produtos(Console.ReadLine(), double.Parse(Console.ReadLine()));
    product_list.Add(produto);

    Console.WriteLine("Digite 1 para continuar e qualquer outra tecla para terminar:");

    if (Console.ReadLine() != "1")
    {
        break;
    }
}

Console.WriteLine("\nDigite a forma de pagamento:");
Carrinho carrinho = new Carrinho(product_list, Console.ReadLine());
carrinho.apresentar_produtos();