using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Npgsql;

public class Program
{
    static void Main()
    {
        string acao;
        for (int i = 0; i < 2;)
        {
            Console.WriteLine("\nDigite uma das seguintes opções:\n 1 - Inserir - inserir um aluno com nome e RA\n 2 - Listar - Apresentar alunos");
            Console.WriteLine(" 3 - Buscar - Busca uma lista de todos os alunos\n 4 - Excluir - Excluir um aluno a partir do seu id");
            Console.WriteLine(" 5 - Atualizar - Atualiza um aluno com determinado id\n 6 - Sair - encerra o programa");
            acao = Console.ReadLine().ToLower();
            switch(acao)
            {
                case "inserir":
                case "1":
                    InserirAluno();
                    break;
                case "listar":
                case "2":
                    ListaAluno();
                    break;
                case "buscar":
                case "3":
                    BuscaAluno();
                    break;
                case "excluir":
                case "4":
                    ExcluirAluno();
                    break;
                case "atualizar":
                case "5":
                    AtualizarAluno();
                    break;
                case "sair":
                case "6":
                    i = 2;
                    break;
                default:
                    Console.WriteLine("Não bate com nenhuma opção, digite novamente;");
                    break;

            }
        }

    }

    private static string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=PostgreSQL123;Database=AulaDB";
    public static void InserirAluno()
    {
        string sql = "INSERT INTO aluno (nome, RA)VALUES(@nome, @RA)";
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    Console.WriteLine("Digite o nome do aluno a ser inserido:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite um RA com apenas números");
                    int RA = int.Parse(Console.ReadLine());
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("RA", RA);
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Cliente {nome} inserido com sucesso.Linhas afetadas: {linhasAfetadas} ");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro ao inserir dados:{ex.Message}");

            }
        }
    }

    public static void ListaAluno()
    {
        string sql = "SELECT id, nome, RA FROM aluno ORDER BY id";
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine($"\n--- Alunos -- - ");
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nenhum cliente encontrado.");
                            return;
                        }
                        // 3. Processamento do Resultado
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);
                            int ra = reader.GetInt32(2);
                            Console.WriteLine($"ID: {id}, Nome: {nome}, RA:{ra}");
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro ao consultar dados: {ex.Message}");
            }
        }
    }

    public static void BuscaAluno()
    {
        string sql = "SELECT nome, RA FROM aluno WHERE id = @id ORDER BY id";
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    Console.WriteLine("Qual o id do aluno que deseja procurar?");
                    int id = int.Parse(Console.ReadLine());
                    cmd.Parameters.AddWithValue("id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine($"\n--- Alunos -- - ");
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nenhum cliente encontrado.");
                            return;
                        }
                        while (reader.Read())
                        {
                            string nome = reader.GetString(0);
                            int ra = reader.GetInt32(1);
                            Console.WriteLine($"ID: {id}, Nome: {nome}, RA:{ra}");
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro ao consultar dados: {ex.Message}");
            }
        }
    }

    public static void ExcluirAluno()
    {
        string sql = "DELETE FROM aluno WHERE id = @id";
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    Console.WriteLine("Digite o id do aluno a ser excluido:");
                    int id = int.Parse(Console.ReadLine());
                    cmd.Parameters.AddWithValue("id", id);
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Cliente de id: {id} foi excluído.");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro ao excluir dados:{ex.Message}");

            }
        }
    }
    
    public static void AtualizarAluno()
    {
        string sql = "UPDATE aluno set nome = @nome, ra = @ra WHERE id = @id";
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    Console.WriteLine("Digite o id do aluno a ser atualizado:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome do aluno para atualização:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite um RA para atualização:");
                    int RA = int.Parse(Console.ReadLine());

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("RA", RA);
                    int linhasAfetadas = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Cliente {nome} atualizado com sucesso.Linhas afetadas: {linhasAfetadas} ");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Erro ao atualizar dados:{ex.Message}");

            }
        }
    }
}
