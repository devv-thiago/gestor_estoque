using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_estoque
{
    internal interface IEstoque
    {


        protected void adicionarProduto(string nomeProduto, string descricao, double preco, int quantidadeEstoque);
        protected void listarProdutos();
        protected void listarProdutoNome(string nomeProduto);
        protected void atualizarProduto(int id);
        protected void excluirProduto(int id);

    }
}
