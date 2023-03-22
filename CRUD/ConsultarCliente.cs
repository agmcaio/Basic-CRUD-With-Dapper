using ClienteProjectDapper.Models;
using Dapper;
using System.Data.SqlClient;

namespace ClienteProjectDapper.CRUD
{
    public static class ConsultarCliente
    {
        public static async void Consultar(string connection)
        {
            using(var db = new SqlConnection(connection))
            {
                await db.OpenAsync();
                var query = @"
                    Select Top 10 
                        [ClienteId], 
                        [Cpf], 
                        [Nome], 
                        [Idade], 
                        [Email], 
                        [Pais]
                    From
                        [Clientes]";

                var clientes = await db.QueryAsync<Cliente>(query);

                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"{cliente.ClienteId.ToString()} - {cliente.Cpf}, {cliente.Nome}, {cliente.Idade}, {cliente.Email}, {cliente.Pais}");
                }
                Console.ReadLine();
            }
        }
    }
}
