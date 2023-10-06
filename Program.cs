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
enum MenuMovimentacao
{
    Entrada = 1,
    Saida,
    listar,
    Retorna
}
enum MenuRelatorio
{
    Produto = 1,
    Movimentacao,
    Retorna
}

internal class Program
{
    private static void Main(string[] args)
    {
        bool continua = false;
        MovimentacaoEstoque estoque = new MovimentacaoEstoque();
        Relatorio relatorio = new Relatorio();
        estoque.LoadData();
        while (!continua)
        {
            Console.WriteLine("--CONTROLE DE ESTOQUE--\n");
            Console.WriteLine("Escolha uma opcao:");
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
                                Console.WriteLine("Digite o ID do item que deseja atualizar as informacoes: ");
                                int id = int.Parse(Console.ReadLine());
                                estoque.atualizarProduto(id);
                                Console.WriteLine("Produto atualizado com sucesso.");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                            case MenuProduto.Excluir:
                                Console.WriteLine("Digite o ID do item que deseja fazer a exclusao: ");
                                int idProduto = int.Parse(Console.ReadLine());
                                estoque.excluirProduto(idProduto);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Console.ReadLine();
                                break;
                            case MenuProduto.Listar_produtos:
                                estoque.listarProdutos();
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuProduto.Pesquisar:
                                Console.Write("Digite o nome do produto que deseja: ");
                                string nomeProduto = Console.ReadLine();
                                estoque.listarProdutoNome(nomeProduto);
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
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
                   
                    bool sair2 = false;
                    while (!sair2) {
                        Console.WriteLine("Escolha a acao que quer fazer:\n1-Registrar entrada.\n2-Registrar saida.\n3-Listar movimentacoes.\n4-Retornar menu principal");
                        MenuMovimentacao opcao3 = (MenuMovimentacao)int.Parse(Console.ReadLine());
                    
                        switch (opcao3)
                        {
                            case MenuMovimentacao.Entrada:
                                estoque.entradaProduto();
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuMovimentacao.Saida:
                                estoque.saidaProduto();
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuMovimentacao.listar:
                                estoque.listarMovimentacoes();
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuMovimentacao.Retorna:
                                sair2 = !sair2;
                                Console.WriteLine("Retornando...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                        }
                    }
                        
                    break;
                case MenuPrincipal.relatorio:
                    bool sair3 = false;
                    while (!sair3)
                    {
                        Console.WriteLine("Escolha a acao que quer fazer:\n1-Relatorio de produtos.\n2-Relatorio de movimentacoes.\n3-Retornar menu principal");
                        MenuRelatorio opcao4 = (MenuRelatorio)int.Parse(Console.ReadLine());
                        switch (opcao4)
                        {
                            case MenuRelatorio.Produto:
                                relatorio.relatorioProduto(estoque.produtos);
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear(); 
                                break;
                            case MenuRelatorio.Movimentacao:
                                relatorio.relatorioMovimentacao(estoque.movimentacoes);
                                Console.WriteLine("Aperte ENTER para voltar ao menu.");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            case MenuRelatorio.Retorna:
                                sair2 = !sair3;
                                Console.WriteLine("Retornando...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                    }
                    }
                    
                    break;
                case MenuPrincipal.sair:
                    estoque.SaveData();
                    continua = !continua;
                    break;
            }
        }
    }
}