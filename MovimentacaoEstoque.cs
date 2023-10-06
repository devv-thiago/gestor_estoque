using gestor_estoque.models;
using System;
using System.Collections.Generic;

namespace gestor_estoque
{
    internal class MovimentacaoEstoque : IEstoque
    {
        public List<ProdutoModel> produtos = new List<ProdutoModel>();
        public List<MovimentacaoModel> movimentacoes = new List<MovimentacaoModel>();

        private DataPersistence dataPersistence = new DataPersistence();

        // Restante do código...

        public void LoadData()
        {
            produtos = dataPersistence.LoadProdutos();
            movimentacoes = dataPersistence.LoadMovimentacoes();
        }

        public void SaveData()
        {
            dataPersistence.SaveProdutos(produtos);
            dataPersistence.SaveMovimentacoes(movimentacoes);
        }

        public void adicionarProduto(string nomeProduto, string descricao, double preco, int quantidadeEstoque)
        {
            try
            {
                ProdutoModel produto = new ProdutoModel(nomeProduto, descricao, preco, quantidadeEstoque);
                produtos.Add(produto);
                Console.WriteLine("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar produto: {ex.Message}");
            }
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
                double preco;
                if (!double.TryParse(Console.ReadLine(), out preco))
                {
                    Console.WriteLine("Preço inválido. A atualização será cancelada.");
                    return;
                }
                Console.Write("Digite a quantidade de estoque atualizado: ");
                int quantidadeEstoque;
                if (!int.TryParse(Console.ReadLine(), out quantidadeEstoque))
                {
                    Console.WriteLine("Quantidade de estoque inválida. A atualização será cancelada.");
                    return;
                }

                Console.Clear();
                Console.WriteLine("Verifique as informações: ");
                Console.WriteLine($"Nome atualizado: {nome}");
                Console.WriteLine($"Descricao atualizada: {descricao}");
                Console.WriteLine($"Preco atualizado: {preco}");
                Console.WriteLine($"Quantidade estoque atualizada: {quantidadeEstoque}");
                Console.Write("Confirmar atualizacao? S/n ");
                string resposta = Console.ReadLine();
                if (resposta.ToLower().Equals("s"))
                {
                    produtos[indexProdAtualizar] = new ProdutoModel(nome, descricao, preco, quantidadeEstoque);
                }
                else
                {
                    Console.Clear();
                    atualizarProduto(idProd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        public void excluirProduto(int id)
        {
            try
            {
                var produtoParaExcluir = produtos.FirstOrDefault(x => x.Id == id);
                if (produtoParaExcluir != null)
                {
                    produtos.Remove(produtoParaExcluir);
                    Console.WriteLine("Item excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine("Item não encontrado.");
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine($"Erro ao excluir produto: {excep.Message}");
            }
        }

        public void listarProdutoNome(string nomeProduto)
        {
            try
            {
                foreach (var produto in produtos)
                {
                    if (string.Equals(nomeProduto, produto.NomeProduto, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"ID: {produto.Id} - Nome: {produto.NomeProduto} - Descricao: {produto.Descricao} - Preco: R${produto.Preco} - Estoque: {produto.QuantidadeEstoque}");
                    }
                }
            }
            catch (Exception excep)
            {
                Console.WriteLine($"Erro ao listar produtos por nome: {excep.Message}");
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
                Console.WriteLine($"Erro ao listar produtos: {excep.Message}");
            }
        }

        public void entradaProduto()
        {
            Console.Write("Qual ID do produto para atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int idProdutoAtualizar))
            {
                Console.WriteLine("ID inválido. A operação será cancelada.");
                return;
            }

            ProdutoModel produtoAtualizacao = produtos.Find(x => x.Id == idProdutoAtualizar);
            string operacaoEntrda = "Entrada";

            if (produtoAtualizacao != null)
            {
                Console.Write("Quantos itens foram adicionados ao estoque: ");
                if (int.TryParse(Console.ReadLine(), out int quantidadeEntrada))
                {
                    produtoAtualizacao.QuantidadeEstoque += quantidadeEntrada;
                    registroMovimentacao(produtoAtualizacao.Id, produtoAtualizacao.NomeProduto, operacaoEntrda);
                    Console.WriteLine("Produto atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Quantidade inválida. A operação será cancelada.");
                }
            }
            else
            {
                Console.WriteLine("ID inexistente, digite o ID de um produto existente.");
            }
        }

        public void saidaProduto()
        {
            Console.Write("Qual ID do produto para atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int idProdutoAtualizar))
            {
                Console.WriteLine("ID inválido. A operação será cancelada.");
                return;
            }

            ProdutoModel produtoAtualizacao = produtos.Find(x => x.Id == idProdutoAtualizar);
            string operacaoSaida = "Saida";

            if (produtoAtualizacao != null)
            {
                Console.Write("Quantos itens foram retirados do estoque: ");
                if (int.TryParse(Console.ReadLine(), out int quantidadeSaida))
                {
                    if (quantidadeSaida <= produtoAtualizacao.QuantidadeEstoque)
                    {
                        produtoAtualizacao.QuantidadeEstoque -= quantidadeSaida;
                        registroMovimentacao(produtoAtualizacao.Id, produtoAtualizacao.NomeProduto, operacaoSaida);
                        Console.WriteLine("Produto atualizado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de saída maior que o estoque disponível. A operação será cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Quantidade inválida. A operação será cancelada.");
                }
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
