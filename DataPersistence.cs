using gestor_estoque.models;
using System.Xml;
using Newtonsoft.Json;

namespace gestor_estoque
{
    internal class DataPersistence
    {
        private const string ProdutosFilePath = "produtos.json";
        private const string MovimentacoesFilePath = "movimentacoes.json";

        public void SaveProdutos(List<ProdutoModel> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ProdutosFilePath, json);
        }

        public List<ProdutoModel> LoadProdutos()
        {
            if (File.Exists(ProdutosFilePath))
            {
                string json = File.ReadAllText(ProdutosFilePath);
                return JsonConvert.DeserializeObject<List<ProdutoModel>>(json);
            }
            return new List<ProdutoModel>();
        }

        public void SaveMovimentacoes(List<MovimentacaoModel> movimentacoes)
        {
            string json = JsonConvert.SerializeObject(movimentacoes, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(MovimentacoesFilePath, json);
        }

        public List<MovimentacaoModel> LoadMovimentacoes()
        {
            if (File.Exists(MovimentacoesFilePath))
            {
                string json = File.ReadAllText(MovimentacoesFilePath);
                return JsonConvert.DeserializeObject<List<MovimentacaoModel>>(json);
            }
            return new List<MovimentacaoModel>();
        }
    }
}