using APIFornecedor.Controllers;

namespace Api_Fornecedor.Models
{
    public class Conexao
    {
        public void Conecta()
        {
            var path = new StreamReader(@"C:\Users\tayna_97l6kwx\OneDrive\Documentos\3° Ano - 2° Bimestre\PDS\ApiConexao");
            using (path)
            {
                while (!path.EndOfStream)
                {
                    var conexao = new FornecedorController();
                    var pathline = conexao.Put;
                    Console.WriteLine(pathline);
                }
            }
        }
    }
}
