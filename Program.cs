using ClienteProjectDapper.CRUD;
using Microsoft.Extensions.Configuration;
using System;

class Program
{
    public static IConfigurationRoot Configuration { get; private set; }

    static void Main(string[] args)
    {
        // Passando o arquivo que contém a connection string
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);

        Configuration = builder.Build();

        string _connection = Configuration["ConnectionString:DefaultConnection"];

        Console.WriteLine("c - Consultar");
        Console.WriteLine("i - Incluir");
        Console.WriteLine("a - Atualizar");
        Console.WriteLine("d - Deletar");
        Console.WriteLine("Escolha uma opção (c,i,d,a).");
        char option = char.Parse(Console.ReadLine().ToLower());

        switch (option)
        {
            case 'c':
                ConsultarCliente.Consultar(_connection);
                break;
            case 'i':
                IncluirClientes.Incluir(_connection);
                break;
            case 'a':
                AtualizarCliente.Atualizar(_connection);
                break;
            case 'd':
                DeletarCliente.Delete(_connection);
                break;
        }
        Console.ReadKey();
    }
}