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
            try
            {
                Stream fileStream = new FileStream("Produtos.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                String cabecalho = "Produtos" + ";\n";
                byte[] cabecalhoBytes = System.Text.Encoding.UTF8.GetBytes(cabecalho);

                fileStream.Write(cabecalhoBytes, 0, cabecalhoBytes.Length);

                 cabecalho = "Id;Nome produto;Descricao;Preco;Quantidade estoque;\n";
                 cabecalhoBytes = System.Text.Encoding.UTF8.GetBytes(cabecalho);

                fileStream.Write(cabecalhoBytes, 0, cabecalhoBytes.Length);


                foreach (var produto in produtos)
                {
                    String textoProduto = produto.Id + ";" + produto.NomeProduto + ";" + produto.Descricao + ";" + produto.Preco + ";" + produto.QuantidadeEstoque + ";\n";
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textoProduto);

                    fileStream.Write(bytes, 0, bytes.Length);
                }

                fileStream.Close();
                Console.WriteLine("Arquivo criado com sucesso!");
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void relatorioMovimentacao(List<MovimentacaoModel> movimentacoes)
        {
            try
            {
                Stream fileStream = new FileStream("Movimentacoes.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                String cabecalho = "Movimentacoes" + ";\n";
                byte[] cabecalhoBytes = System.Text.Encoding.UTF8.GetBytes(cabecalho);

                fileStream.Write(cabecalhoBytes, 0, cabecalhoBytes.Length);

                cabecalho = "Id;Data;Tipo;Quantidade;\n";
                cabecalhoBytes = System.Text.Encoding.UTF8.GetBytes(cabecalho);

                fileStream.Write(cabecalhoBytes, 0, cabecalhoBytes.Length);
                foreach (var movimentacao in movimentacoes)
                {
                    String textoMovimentacao = $"{movimentacao.IdMovimentacao};{movimentacao.IdProduto};{movimentacao.NomeProduto};{movimentacao.Operacao};{movimentacao.DataMovimentacao};\n";
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textoMovimentacao);

                    fileStream.Write(bytes, 0, bytes.Length);
                }
            
                fileStream.Close();
                Console.WriteLine("Arquivo de movimentações criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
