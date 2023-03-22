using ClienteProjectDapper.Models;
using Dapper;
using System.Data.SqlClient;

public static class AtualizarCliente
{
    public static async void Atualizar(string connection)
    {
        using(var db = new SqlConnection(connection))
        {
            Cliente cliente = new Cliente();

            Console.WriteLine("Insira o ID do Cliente que você deseja fazer uma atualização:");
            cliente.ClienteId = int.Parse(Console.ReadLine());
            Console.WriteLine("Cpf:");
            cliente.Cpf = Console.ReadLine();
            Console.WriteLine("Nome:");
            cliente.Nome = Console.ReadLine();
            Console.WriteLine("Idade:");
            cliente.Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Email:");
            cliente.Email = Console.ReadLine();
            Console.WriteLine("País:");
            cliente.Pais = Console.ReadLine();

            try
            {
                await db.OpenAsync();
                var query = @"
                    Update 
                        Clientes 
                    Set 
                        Cpf=@@pf,
                        Nome=@Nome, 
                        Idade=@Idade,
                        Email=@Email,
                        Pais=@Pais
                    Where
                        ClienteId=@ClienteId
                ";

                await db.ExecuteAsync(query, cliente);

                Console.WriteLine($"Cliente {cliente.Nome} atualizado com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}