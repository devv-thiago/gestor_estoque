using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_estoque
{
    internal interface IEstoque
    {
        void adicionarProduto();
        void listarProduto();
        void atualizarProduto();
        void excluirProduto();

    }
}
