using gestor_estoque.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace gestor_estoque
{
    internal class Relatorio
    {
        public void relatorioProduto(List<ProdutoModel> produtos)
        {
            Stream fileStream = new FileStream("Produtos.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            foreach (var produto in produtos)
            {
                String textoProduto = produto.Id + ";" + produto.NomeProduto + ";" + produto.Descricao + ";" + produto.Preco + ";" + produto.QuantidadeEstoque + ";\n";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textoProduto);

                fileStream.Write(bytes, 0, bytes.Length);
            }

            fileStream.Close();
        }
        public void relatorioMovimentacao(List<MovimentacaoModel> movimentacoes)
        {

        }
    }
}
