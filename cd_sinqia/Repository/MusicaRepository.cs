using Dapper;
using MySqlConnector;

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
            string query = "INSERT INTO musica (musica_id, cd_id, nome_musica, tempo_segundos) VALUES (@musicaId, @id, @nomeMusica, @tempoSegundos)";
            DynamicParameters parametros = new(musica);

            using MySqlConnection conn = new MySqlConnection(_stringConnection);
            conn.Execute(query, parametros);

            return "Musica criada com sucesso!";
        }

        public string EditarMusica(Musica musica, int id)
        {
            string query = "UPDATE musica SET nome_musica = @nomeMusica, tempo_segundos = @tempoSegundos WHERE musica_id = @id";
            DynamicParameters parametros = new(musica);
            parametros.Add("id", id);

            using MySqlConnection conn = new MySqlConnection(_stringConnection);
            conn.Execute(query, parametros);

            return "Musica editada com sucesso!";
        }

        public string ExcluirMusica(int id)
        {
            string query = "DELETE musica WHERE musica_id = @id";
            DynamicParameters parametros = new();
            parametros.Add("id", id);

            using MySqlConnection conn = new MySqlConnection(_stringConnection);
            conn.Execute(query, parametros);

            return "Música exluida com sucesso!";
        }

    }
}
