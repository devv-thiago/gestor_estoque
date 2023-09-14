using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_estoque.models
{
    internal class MovimentacaoModel
    {
        private int idMovimentacao;
        private int idProduto;
        private string nomeProduto;
        private string operacao;
        protected private static int proximoId = 1;

        public MovimentacaoModel(int idProduto, string nomeProduto, string operacao)
        {
            this.idMovimentacao = proximoId++;
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.operacao = operacao;
        }

        public int IdMovimentacao { get => idMovimentacao; set => idMovimentacao = value; }
        public int IdProduto { get => idProduto; set => idProduto = value; }
        public string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public string Operacao { get => operacao; set => operacao = value; }
    }
}
