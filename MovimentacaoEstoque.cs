using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace gestor_estoque
{
    internal class MovimentacaoEstoque : IEstoque
    {
        static List<ProdutoModel> produtos = new List<ProdutoModel>();

        public void adicionarProduto(string nomeProduto, string descricao, double preco, int quantidadeEstoque)
        {
            ProdutoModel produto = new ProdutoModel(nomeProduto, descricao, preco, quantidadeEstoque);
            produtos.Add(produto);
        }

        public void atualizarProduto(int id, string nomeProduto)
        {
            throw new NotImplementedException();
        }

        public void excluirProduto(int id)
        {
            try {
                foreach (var produto in produtos)
                {
                    if (produto.Id == id)
                    {
                        produtos.RemoveAt(id);
                    }
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine(excep);
            }

        }

        public void listarProdutoNome(string nomeProduto)
        {
            try
            {
                foreach (var produto in produtos)
                {
                    if (nomeProduto == produto.NomeProduto)
                    {
                        Console.WriteLine($"ID: {produto.Id} - Nome: {produto.NomeProduto} - Descricao: {produto.Descricao} - Preco: R${produto.Preco} - Estoque: {produto.QuantidadeEstoque}");
                    } else
                    {
                        Console.WriteLine("Produto nao encontrado, verifique as informacoes.");
                    }

                }
            }
            catch (Exception excep)
            {
                Console.WriteLine(excep);
            }
        }

        public void listarProdutos()
        {
            try
            {
                if (produtos.Count == 0)
                {
                    Console.WriteLine("Lista vazia, adicione novos itens.");
                }
                else
                {
                    foreach (var produto in produtos)
                    {
                        Console.WriteLine($"ID: {produto.Id} - Nome: {produto.NomeProduto} - Descricao: {produto.Descricao} - Preco: R${produto.Preco} - Estoque: {produto.QuantidadeEstoque}");
                    }
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine(excep);
            }
         
        }
    }
}
