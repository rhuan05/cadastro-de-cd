using Dapper;
using Microsoft.Data.SqlClient;

namespace cd_sinqia.Repository
{
    public class MusicaRepository
    {

        private string _stringConnection { get; set; }

        //Pegando a string connection
        public MusicaRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        //Métodos do repository
        public string InserirMusica(Musica musica)
        {
            try
            {
                string query = "INSERT INTO musica (cd_id, nome_musica, tempo_segundos) VALUES (@cdId, @nomeMusica, @tempoSegundos)";
                DynamicParameters parametros = new(musica);

                SqlConnection conn = new SqlConnection(_stringConnection);
                conn.Execute(query, parametros);

                return "Musica criada com sucesso!";
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return "Não foi possível criar essa música!";
            }
        }

        public string EditarMusica(Musica musica, int id)
        {
            try
            {
                string query = "UPDATE musica SET nome_musica = @nomeMusica, tempo_segundos = @tempoSegundos WHERE musica_id = @id";
                DynamicParameters parametros = new(musica);
                parametros.Add("id", id);

                SqlConnection conn = new SqlConnection(_stringConnection);
                conn.Execute(query, parametros);

                return "Musica editada com sucesso!";
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return "Não foi possível editar essa música!";
            }
        }

        public string ExcluirMusica(int id)
        {
            try
            {
                string query = "DELETE musica WHERE musica_id = @id";
                DynamicParameters parametros = new();
                parametros.Add("id", id);

                SqlConnection conn = new SqlConnection(_stringConnection);
                conn.Execute(query, parametros);

                return "Música exluida com sucesso!";
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return "Não foi possível deletar essa música!";
            }
        }

    }
}
