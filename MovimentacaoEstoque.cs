﻿using gestor_estoque.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace gestor_estoque
{
    internal class MovimentacaoEstoque : IEstoque
    {
        static List<ProdutoModel> produtos = new List<ProdutoModel>();
        static List<MovimentacaoModel> movimentacoes = new List<MovimentacaoModel>();

        public void adicionarProduto(string nomeProduto, string descricao, double preco, int quantidadeEstoque)
        {
            try
            {
                ProdutoModel produto = new ProdutoModel(nomeProduto, descricao, preco, quantidadeEstoque);
                produtos.Add(produto);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void atualizarProduto(int id)
        {
            int idProd = id; 
        try
            {
                int indexProdAtualizar = produtos.FindIndex(x => x.Id == id);
                Console.Write("Digite o nome atualizado do produto: ");
                string nome = Console.ReadLine();
                Console.Write("Digite a descricao atualizada: ");
                string descricao = Console.ReadLine();
                Console.Write("Digite o preco atualizado: ");
                double preco = double.Parse(Console.ReadLine());
                Console.Write("Digite a quantidade de estoque atualizado: ");
                int quantidadeEstoque = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Verique as informacoes: ");
                Console.WriteLine($"Nome atualizado: {nome}");
                Console.WriteLine($"Descricao atualizada: {descricao}");
                Console.WriteLine($"Preco atualizado: {preco}");
                Console.WriteLine($"Quantidade estoque atualizada: {quantidadeEstoque}");
                Console.Write("Confirmar atualizacao? S/n ");
                string resposta = Console.ReadLine();
                if (resposta.ToLower().Equals("s")) {
                    produtos[indexProdAtualizar] = new ProdutoModel(nome, descricao, preco, quantidadeEstoque);
                } else
                {
                    Console.Clear();
                    atualizarProduto(idProd);
                }
                
            }
            catch (Exception ex) { Console.WriteLine( ex.ToString()); }
        }

        public void excluirProduto(int id)
        {
            try {
                var produtoParaExcluir = produtos.FirstOrDefault(x => x.Id == id);
                    if (id != null)
                    {
                        produtos.Remove(produtoParaExcluir);
                        Console.WriteLine("Item excluído com sucesso.");
                    } else
                    {
                        Console.WriteLine("Item nao encontrado.");
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
        public void entradaProduto()
        {
            Console.Write("Qual ID do produto para atualizar: ");
            int idProdutoAtualizar = int.Parse(Console.ReadLine());
            ProdutoModel produtoAtualizacao = produtos.Find(x => x.Id == idProdutoAtualizar);
            string operacaoEntrda = "Entrada";
            if (produtoAtualizacao != null)
            {
                Console.Write("Quantos itens foram adicionados ao estoque: ");
                int quantidadeEntrada = int.Parse(Console.ReadLine());
                produtoAtualizacao.QuantidadeEstoque = quantidadeEntrada;
                registroMovimentacao(produtoAtualizacao.Id, produtoAtualizacao.NomeProduto, operacaoEntrda);
                Console.WriteLine("Produto atualizado com sucesso.");
                
            } else
            {
                Console.WriteLine("ID inexistente, digite o ID de um produto existente.");
            }
        }

        public void saidaProduto()
        {
            Console.Write("Qual ID do produto para atualizar: ");
            int idProdutoAtualizar = int.Parse(Console.ReadLine());
            ProdutoModel produtoAtualizacao = produtos.Find(x => x.Id == idProdutoAtualizar);
            string operacaoSaida = "Saida";
            if (produtoAtualizacao != null)
            {

                Console.Write("Quantos itens foram retirados do estoque: ");
                int quantidadeSaida = int.Parse(Console.ReadLine());
                produtoAtualizacao.QuantidadeEstoque = produtoAtualizacao.QuantidadeEstoque - quantidadeSaida;
                registroMovimentacao(produtoAtualizacao.Id, produtoAtualizacao.NomeProduto, operacaoSaida);
                Console.WriteLine("Produto atualizado com sucesso.");
                
            }
            else
            {
                Console.WriteLine("ID inexistente, digite o ID de um produto existente.");
            }
            
        }
        private void registroMovimentacao(int idProduto, string nomeProduto, string operacao)
        {
            MovimentacaoModel movimentacao = new MovimentacaoModel(idProduto, nomeProduto, operacao);
            movimentacoes.Add(movimentacao);
        }
        public void listarMovimentacoes()
        {
            foreach (var movimentacao in movimentacoes)
            {
                Console.WriteLine($"ID movimentacao: {movimentacao.IdMovimentacao} - ID produto: {movimentacao.IdProduto} - Nome produto: {movimentacao.NomeProduto} - Operacao: {movimentacao.Operacao} - Data movimentacao: {movimentacao.DataMovimentacao}");
            }
        }
    }
}
