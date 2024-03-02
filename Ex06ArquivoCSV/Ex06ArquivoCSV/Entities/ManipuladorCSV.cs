using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06ArquivoCSV.Entities
{
    internal class ManipuladorCSV
    {
        public static string LerArquivo(string caminho)
        {
            if (!File.Exists(caminho))
                throw new FileNotFoundException("O ficheiro não existe");

            try
            {
                return File.ReadAllText(caminho);
            }
            catch(FileLoadException ex)
            {
                throw new("Erro ao carregar o ficheiro: " + ex.Message);
            }
            catch(UnauthorizedAccessException ex)
            {
                throw new("Accesso negado: " + ex.Message);
            }
            catch (IOException ex)
            {
                throw new("Erro com o ficheiro: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new("Erro inesperado: " + ex.Message);
            }
        }
    }
}
