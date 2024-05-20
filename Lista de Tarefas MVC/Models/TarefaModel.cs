using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Lista_de_Tarefas_MVC.Models
{
    public class TarefaModel : IDisposable
    {
        private SqlConnection connection;

        public TarefaModel()
        {
            //string strConn="Data Source=localhost;Initial Catalog=BDContato;Integrated Security=true";
            string strConn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ListaDeTarefas;Integrated Security=True";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Tarefa tarefa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Tarefa VALUES (@descricao)";

            cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);

            cmd.ExecuteNonQuery();
        }

        public void Update(Tarefa tarefa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Tarefa SET Descricao=@descricao WHERE Id=@id";

            cmd.Parameters.AddWithValue("@descricao", tarefa.Descricao);
            cmd.Parameters.AddWithValue("@id", tarefa.Id);

            cmd.ExecuteNonQuery();
        }

        public List<Tarefa> Read()
        {
            List<Tarefa> lista = new List<Tarefa>();
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM Tarefa", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Id = (int)reader["Id"];
                tarefa.Descricao = (string)reader["Descricao"];

                lista.Add(tarefa);
            }

            return lista;
        }
    }
}
