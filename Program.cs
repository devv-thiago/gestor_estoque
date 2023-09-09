using gestor_estoque;
using Microsoft.Win32;
using System.Collections.Generic;

enum MenuPrincipal
{
    produto = 1,
    movimentacao,
    relatorio,
    sair 
}
enum MenuProduto
{
    Adicionar = 1,
    Atualizar,
    Excluir,
    Listar_produtos,
    Pesquisar,
    Retorna
}

internal class Program
{
    private static void Main(string[] args)
    {
        bool continua = false;
        MovimentacaoEstoque estoque = new MovimentacaoEstoque();
        while (!continua)
        {
            Console.WriteLine("--CONTROLE DE ESTOQUE--\n");
            Console.WriteLine("Que tipo de ação quer fazer?");
            Console.WriteLine("1-Adicionar/Atualizar/Excluir/Listar produtos.\n2-Registrar movimentações de estoque.\n3-Gerar relatórios.\n4-Sair.");
            MenuPrincipal opcao1 = (MenuPrincipal)int.Parse(Console.ReadLine());
            Thread.Sleep(500);
            Console.Clear();
            switch (opcao1)
            {
                case MenuPrincipal.produto:
                    bool sair = false;
                    while (!sair)
                    {
                        Console.WriteLine("Escolha a acao que quer fazer:\n1-Adicionar novo produto.\n2-Atualizar produto.\n3-Excluir produto.\n4-Listar todos produtos.\n5-Pesquisar produto.\n6-Retornar menu principal");
                        MenuProduto opcao2 = (MenuProduto)int.Parse(Console.ReadLine());
                        switch (opcao2)
                        {

                            case MenuProduto.Adicionar:
                                Console.Write("Digite o nome do produto: ");
                                String nome = Console.ReadLine();
                                Console.Write("Digite a descricao do produto: ");
                                String descricao = Console.ReadLine();
                                Console.Write("Digite o preco do produto: ");
                                double preco = double.Parse(Console.ReadLine());
                                Console.Write("Digite a quantidade em estoque do produto: ");
                                int quantidadeEstoque = int.Parse(Console.ReadLine());
                                estoque.adicionarProduto(nome,descricao,preco,quantidadeEstoque);
                                Console.WriteLine("Aperte ENTER para continuar.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuProduto.Atualizar:
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            case MenuProduto.Excluir:
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            case MenuProduto.Listar_produtos:
                                estoque.listarProdutos();
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuProduto.Pesquisar:
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            case MenuProduto.Retorna:
                                sair = !sair;
                                Console.WriteLine("Retornando...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                        }
                    }
                    
                    break;
                case MenuPrincipal.movimentacao:
                    Console.WriteLine("Em desenvolvimento");
                    Console.Clear();
                    break;
                case MenuPrincipal.relatorio:
                    Console.WriteLine("Em desenvolvimento");
                    Console.Clear();
                    break;
                case MenuPrincipal.sair:
                    continua = !continua;
                    Console.WriteLine("Saindo...");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}