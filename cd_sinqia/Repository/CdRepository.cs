using Dapper;
using Microsoft.Data.SqlClient;

namespace cd_sinqia.Repository
{
    public class CdRepository
    {
        
        private string _stringConnection { get; set; }
        //Pegando a string connection
        public CdRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        //Métodos do repository
        public string InserirCd(Cd cd)
        {
            string query = "INSERT INTO cd (cd_id, nome, autor, data_criacao) VALUES (@id, @nome, @autor, @dataCriacao)";
            DynamicParameters parametros = new(cd);

            SqlConnection conn = new SqlConnection(_stringConnection);
            conn.Execute(query, parametros);

            return "Cd criado com sucesso!";
        }

        public string EditarCd(Cd cd, int id)
        {
            string query = "UPDATE cd SET nome = @nome, autor = @autor, data_criacao = @dataCriacao WHERE cd_id = @id";
            DynamicParameters parametros = new(cd);
            parametros.Add("id", id);

            SqlConnection conn = new SqlConnection(_stringConnection);
            conn.Execute(query, parametros);

            return "Cd editado com sucesso!";
        }

        public string ExcluirCd(int id)
        {
            string query = "DELETE cd, musica WHERE cd_id = @id";
            DynamicParameters parametros = new();
            parametros.Add("id", id);

            SqlConnection conn = new SqlConnection(_stringConnection);
            conn.Execute(query, parametros);

            return "Cd exluido com sucesso!";
        }

    }
}
