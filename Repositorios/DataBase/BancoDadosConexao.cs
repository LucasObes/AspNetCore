using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRepositorios.DataBase
{
    public class BancoDadosConexao
    {
        public SqlCommand Conectar()
        {
            var conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\73368\source\repos\AspNetCore\Repositorios\DataBase\WindowsFormsBancoDados.mdf;Integrated Security=True";
            conexao.Open();

            var comando = conexao.CreateCommand();

            return comando;
        }
    }
}
