using Api_Fornecedor.DTO;
using Api_Fornecedor.Models;

namespace Api_Fornecedor.Txt
{
    public class FornecedorTXT
    {
        public static string caminho = "C:\\Users\\tayna_97l6kwx\\OneDrive\\Documentos\\3° Ano - 2° Bimestre\\PDS\\Api_Fornecedor\\Api_Fornecedor\\Dados\\Fornecedores.txt";

        private static void SalvaTXT(List<Fornecedor> fornecedores)
        {
            using (var s = new StreamWriter(caminho, false)) 
            {
                foreach (var fornecedor in fornecedores)
                {
                    s.WriteLine($"ID: {fornecedor.Id}.");
                    s.WriteLine($"NomeFantasia: {fornecedor.NomeFantasia}.");
                    s.WriteLine($"RazaoSocial: {fornecedor.RazaoSocial}.");
                    s.WriteLine($"CNPJ: {fornecedor.CNPJ}.");
                    s.WriteLine($"Endereco: {fornecedor.Endereco}.");
                    s.WriteLine($"Cidade: {fornecedor.Cidade}.");
                    s.WriteLine($"Estado: {fornecedor.Estado}.");
                    s.WriteLine($"Telefone: {fornecedor.Telefone}.");
                    s.WriteLine($"Email: {fornecedor.Email}.");
                    s.WriteLine($"Responsavel: {fornecedor.Responsavel}.");
                    s.WriteLine("");
                }
            }
        }

        public static IEnumerable<Fornecedor> ListaTXT()
        {
            var listafornecedoreslidos = new List<Fornecedor>();

            if (File.Exists(caminho))
            {
                var lines = File.ReadAllLines(caminho);
                Fornecedor fornecedor = null;

               
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (fornecedor != null)
                        {
                            listafornecedoreslidos.Add(fornecedor);
                            fornecedor = null;
                        }
                    }
                    else
                    {
                        var parts = line.Split(':', 2);
                        if (parts.Length == 2)
                        {
                            var etiqueta = parts[0].Trim();
                            var informacao = parts[1].Trim().TrimEnd('.');
                           
                            if (etiqueta == "ID")
                            {
                                if (fornecedor != null)
                                {
                                    listafornecedoreslidos.Add(fornecedor);
                                }

                                fornecedor = new Fornecedor { Id = Convert.ToInt32(informacao) };
                            }
                            else if (fornecedor != null)
                            {
                                if (etiqueta == "NomeFantasia")
                                {
                                    fornecedor.NomeFantasia = informacao;
                                }
                                else if (etiqueta == "RazaoSocial")
                                {
                                    fornecedor.RazaoSocial = informacao;
                                }
                                else if (etiqueta == "CNPJ")
                                {
                                    fornecedor.CNPJ = informacao;
                                }
                                else if (etiqueta == "Endereco")
                                {
                                    fornecedor.Endereco = informacao;
                                }
                                else if (etiqueta == "Cidade")
                                {
                                    fornecedor.Cidade = informacao;
                                }
                                else if (etiqueta == "Estado")
                                {
                                    fornecedor.Estado = informacao;
                                }
                                else if (etiqueta == "Telefone")
                                {
                                    fornecedor.Telefone = informacao;
                                }
                                else if (etiqueta == "Email")
                                {
                                    fornecedor.Email = informacao;
                                }
                                else if (etiqueta == "Responsavel")
                                {
                                    fornecedor.Responsavel = informacao;
                                }
                            }
                        }
                    }
                }

                if (fornecedor != null)
                {
                    listafornecedoreslidos.Add(fornecedor);
                }
            }

            SalvaTXT(listafornecedoreslidos);
            return listafornecedoreslidos;
        }


        public static Fornecedor GetById(int id)
        {
            return ListaTXT().Where(item => item.Id == id).FirstOrDefault();
        }

        public static Fornecedor CriaTXT(FornecedorDTO fornecedorDTO)
        {
            var fornecedores = ListaTXT().ToList();
            var proximoId = fornecedores.Count + 1;

            var fornecedor = new Fornecedor();
            fornecedor.Id = proximoId;
            fornecedor.NomeFantasia = fornecedorDTO.NomeFantasia;
            fornecedor.RazaoSocial = fornecedorDTO.RazaoSocial;
            fornecedor.CNPJ = fornecedorDTO.CNPJ;
            fornecedor.Endereco = fornecedorDTO.Endereco;
            fornecedor.Cidade = fornecedorDTO.Cidade;
            fornecedor.Estado = fornecedorDTO.Estado;
            fornecedor.Telefone = fornecedorDTO.Telefone;
            fornecedor.Email = fornecedorDTO.Email;
            fornecedor.Responsavel = fornecedorDTO.Responsavel;



            fornecedores.Add(fornecedor);
            SalvaTXT(fornecedores);
            return fornecedor;
        }

        public static Fornecedor AtualizaTXT(int id, FornecedorDTO fornecedorDTO)
        {
            var fornecedores = ListaTXT().ToList();
            var fornecedorAntigo = GetById(id);

            if (fornecedorAntigo == null)
            {
                return null;
            }

            var fornecedorAtualizado = new Fornecedor
            {
                Id = id,
                NomeFantasia = fornecedorDTO.NomeFantasia,
                RazaoSocial = fornecedorDTO.RazaoSocial,
                CNPJ = fornecedorDTO.CNPJ,
                Endereco = fornecedorDTO.Endereco,
                Cidade = fornecedorDTO.Cidade,
                Estado = fornecedorDTO.Estado,
                Telefone = fornecedorDTO.Telefone,
                Email = fornecedorDTO.Email,
                Responsavel = fornecedorDTO.Responsavel
            };

            var fornecedoresAtualizados = fornecedores.Where(item => item.Id != id).Append(fornecedorAtualizado).ToList();

            SalvaTXT(fornecedoresAtualizados);
            return fornecedorAtualizado;
        }

        public static bool DeletaTXT(int id)
        {
            var fornecedores = ListaTXT().ToList();
            var fornecedor = GetById(id);

            if (fornecedor == null)
            {
                return false;
            }

            fornecedores = fornecedores.Where(item => item.Id != id).ToList();

            SalvaTXT(fornecedores);
            return true;
        }
    }
}
        
   