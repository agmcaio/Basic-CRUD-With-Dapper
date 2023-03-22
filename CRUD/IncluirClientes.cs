using ClienteProjectDapper.Models;
using Dapper;
using System.Data.SqlClient;

namespace ClienteProjectDapper.CRUD
{
    public static class IncluirClientes
    {
        public static async void Incluir(string connection)
        {
            using(var db = new SqlConnection(connection))
            {
                Cliente cliente = new Cliente();
                Console.WriteLine("Insira o Cpf do cliente");
                cliente.Cpf = Console.ReadLine();
                Console.WriteLine("Insira o Nome do cliente");
                cliente.Nome = Console.ReadLine();
                Console.WriteLine("Insira a Idade do cliente");
                cliente.Idade = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o Email do cliente");
                cliente.Email = Console.ReadLine();
                Console.WriteLine("Insira o País do cliente");
                cliente.Pais = Console.ReadLine();

                try
                {
                    await db.OpenAsync();
                    var query = @"
                        Insert Into
                            Clientes(Cpf, Nome, Idade, Email, Pais)
                        Values(
                            @cpf, @nome, @idade, @email, @pais
                        )";

                    await db.ExecuteAsync(query, cliente);

                    await Console.Out.WriteLineAsync($"Cliente {cliente.Cpf} incluido com sucesso");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
