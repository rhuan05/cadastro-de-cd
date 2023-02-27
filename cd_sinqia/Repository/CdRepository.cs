﻿using Dapper;
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
            try
            {
                string query = "INSERT INTO cd (cd_id, nome, autor, data_criacao) VALUES (@id, @nome, @autor, @dataCriacao)";
                DynamicParameters parametros = new(cd);

                SqlConnection conn = new SqlConnection(_stringConnection);
                conn.Execute(query, parametros);

                return "Cd criado com sucesso!";
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return "Não foi possível criar esse cd!";
            }
        }

        public string EditarCd(Cd cd, int id)
        {
            try
            {
                string query = "UPDATE cd SET nome = @nome, autor = @autor, data_criacao = @dataCriacao WHERE cd_id = @id";
                DynamicParameters parametros = new(cd);
                parametros.Add("id", id);

                SqlConnection conn = new SqlConnection(_stringConnection);
                conn.Execute(query, parametros);

                return "Cd editado com sucesso!";
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "Não foi possível editar esse cd!";
            }
        }

        public string ExcluirCd(int id)
        {
            try
            {
                string query = "DELETE FROM cd WHERE cd_id = @id; DELETE FROM musica WHERE cd_id = @id";
                DynamicParameters parametros = new();
                parametros.Add("id", id);

                SqlConnection conn = new SqlConnection(_stringConnection);
                conn.Execute(query, parametros);

                return "Cd exluido com sucesso!";
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "Não foi possível deletar esse cd!";
            }
        }

    }
}
