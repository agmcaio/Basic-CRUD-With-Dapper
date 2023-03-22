using ClienteProjectDapper.Models;
using Dapper;
using System.Data.SqlClient;

public static class DeletarCliente
{
    public static async void Delete(string connection)
    {
        using(var db = new SqlConnection(connection))
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Insira o ID do cliente que você deseja deletar:");
            cliente.ClienteId = int.Parse(Console.ReadLine());

            try
            {
                await db.OpenAsync();

                var query = @"
                    Delete from
                        Clientes
                    Where
                        ClienteId = @ClienteId";

                await db.ExecuteAsync(query, cliente);

                Console.WriteLine("Cliente excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}