using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_estoque
{
    abstract class Produto : IEstoque
    {
        private static int proximoId = 1;
        private int id;
        private string nomeProduto;
        string descricao;
        double preco;
        int quantidadeEstoque;


        protected Produto(string nome, string descricao, double preco, int quantidadeEstoque)
        {
            this.id = proximoId++;
            this.NomeProduto = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.QuantidadeEstoque = quantidadeEstoque;
        }

        public int QuantidadeEstoque { get => quantidadeEstoque; set => quantidadeEstoque = value; }
        public int Id { get => id; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public double Preco { get => preco; set => preco = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        public void adicionarProduto()
        {

        }

        public void atualizarProduto()
        {

        }

        public void excluirProduto()
        {

        }

        public void listarProdutoNome()
        {

        }

        public void listarProdutos()
        {

        }
    }
}


