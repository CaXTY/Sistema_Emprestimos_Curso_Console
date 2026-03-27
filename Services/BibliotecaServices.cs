
using SistemaEmprestimoCursoConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SistemaEmprestimoCursoConsole.Services
{
    internal class BibliotecaServices
    {

        private List<Livro> livros = new List<Livro>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Emprestimo> emprestimos = new List<Emprestimo>();

        private int livroIdCounter = 1;
        private int usuarioIdCounter = 1;
        private int emprestimoIdCounter = 1;


        public void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n ============ MENU BIBLIOTECA ============");
                Console.WriteLine("1. Gerenciar Livros");
                Console.WriteLine("2. Gerenciar Usuários");
                Console.WriteLine("3. Gerenciar Empréstimos");
                Console.WriteLine("0. Sair");
                Console.WriteLine("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuLivros();
                        break;
                    case "2":
                        MenuUsuarios();
                        break;
                    case "3":
                        MenuEmprestimo();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            }
        }

        private void MenuLivros()
        {
            while (true)
            {
                Console.WriteLine("\n ============ Gerenciamento de Livros ============");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar Livros");
                Console.WriteLine("3. Atualizar Livro");
                Console.WriteLine("4. Remover Livro");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarLivro();
                        break;
                    case "2":
                        ListarLivros();
                        break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        RemoverLivro();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void MenuUsuarios()
        {
            while (true)
            {
                Console.WriteLine("\n ============ Gerenciamento de Usuários ============");
                Console.WriteLine("1. Adicionar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Atualizar Usuário");
                Console.WriteLine("4. Remover Usuário");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("Escolha: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        AdicionarUsuario();
                        break;
                    case "2":
                        ListarUsuarios();
                        break;
                    case "3":
                        AtualizarUsuario();
                        break;
                    case "4":
                        RemoverUsuario();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void MenuEmprestimo()
        {
            while (true)
            {
                Console.WriteLine("\n ============ Gerenciamento de Empréstimos ============");
                Console.WriteLine("1. Adicionar Empréstimo");
                Console.WriteLine("2. Listar Empréstimo Ativos");
                Console.WriteLine("3. Devolver Livro");
                Console.WriteLine("4. Histórico de Empréstimos por Usuário");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("Escolha: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarEmprestimo();
                        break;
                    case "2":
                        ListarEmprestimoAtivos();
                        break;
                    case "3":
                        DevolverLivro();
                        break;
                    case "4":
                        HistoricoDeEmprestimoPorUsuario();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

        }





        //Métodos para livros
        private void AdicionarLivro()
        {
            Console.WriteLine("\n ============ Adicionar Livro ============");
            Console.WriteLine("Título: ");
            string titulo = Console.ReadLine();

            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            livros.Add(new Livro { Id = livroIdCounter++, Titulo = titulo, Autor = autor }); //Adiciona um novo livro à lista de livros, utilizando o contador de ID para garantir que cada livro tenha um ID único

            Console.WriteLine("Livro adicionado com sucesso!");
        }

        private void ListarLivros()
        {
            Console.WriteLine("\n ============ Lista de Livros ============");

            foreach (var livro in livros) //foreach para percorrer a lista de livros e exibir as informações de cada livro
            {
                Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Disponível: {(livro.Disponivel ? "Sim" : "Não")}");
            }
        }

        private void AtualizarLivro()
        {
            Console.WriteLine("\n ============ Atualizar Livro ============");
            Console.WriteLine("ID do livro a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var livro = livros.FirstOrDefault(l => l.Id == id); //Busca o livro na lista de livros com base no ID fornecido pelo usuário

            if (livro != null) //Verifica se o livro foi encontrado
            {
                Console.WriteLine("Novo título: ");
                livro.Titulo = Console.ReadLine();

                Console.WriteLine("Novo autor: ");
                livro.Autor = Console.ReadLine();

                Console.WriteLine("Livro atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        private void RemoverLivro()
        {
            Console.WriteLine("\n ============ Remover Livro ============");
            Console.WriteLine("ID do livro a ser removido: ");

            int id = int.Parse(Console.ReadLine());
            var livro = livros.FirstOrDefault(l => l.Id == id); //Busca o livro na lista de livros com base no ID fornecido pelo usuário

            if (livro != null) //Verifica se o livro foi encontrado
            {
                livros.Remove(livro); //Remove o livro da lista de livros
                Console.WriteLine("Livro removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }

        }

        //Métodos para livros
        private void AdicionarUsuario()
        {
            Console.WriteLine("\n ============ Adicionar Usuário ============");

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            usuarios.Add(new Usuario { Id = usuarioIdCounter++, Nome = nome, Email = email }); //Adiciona um novo usuário à lista de usuários, utilizando o contador de ID para garantir que cada usuário tenha um ID único
            Console.WriteLine("Usuário adicionado com sucesso!");
        }

        private void ListarUsuarios()
        {
            Console.WriteLine("\n ============ Lista de Usuários ============");
            foreach (var usuario in usuarios) //foreach para percorrer a lista de usuários e exibir as informações de cada usuário
            {
                Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.Nome} | Email: {usuario.Email}");
            }
        }

        private void AtualizarUsuario()
        {
            Console.WriteLine("\n ============ Atualizar Usuário ============");
            Console.WriteLine("ID do usuário a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var usuario = usuarios.FirstOrDefault(u => u.Id == id); //Busca o usuário na lista de usuários com base no ID fornecido pelo usuário

            if (usuario != null) //Verifica se o usuário foi encontrado
            {
                Console.Write("Novo nome: ");
                usuario.Nome = Console.ReadLine();
                Console.Write("Novo email: ");
                usuario.Email = Console.ReadLine();
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        private void RemoverUsuario()
        {
            Console.WriteLine("\n ============ Remover Usuário ============");
            Console.WriteLine("ID do usuário a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            var usuario = usuarios.FirstOrDefault(u => u.Id == id); //Busca o usuário na lista de usuários com base no ID fornecido pelo usuário

            if (usuario != null) //Verifica se o usuário foi encontrado
            {
                usuarios.Remove(usuario); //Remove o usuário da lista de usuários
                Console.WriteLine("Usuário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        //Métodos Empréstimos 
        private void AdicionarEmprestimo()
        {
            Console.WriteLine("\n ============ Adicionar Empréstimo ============");
            Console.WriteLine("ID do livro a ser emprestado: ");

            int livroId = int.Parse(Console.ReadLine());

            var livro = livros.FirstOrDefault(l => l.Id == livroId); //Busca o livro na lista de livros com base no ID fornecido pelo usuário

            if (livro != null && livro.Disponivel) //Verifica se o livro foi encontrado e está disponível para empréstimo
            {
                Console.WriteLine("ID do usuário que está emprestando: ");
                int usuarioId = int.Parse(Console.ReadLine());

                var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId); //Busca o usuário na lista de usuários com base no ID fornecido pelo usuário

                if (usuario != null) //Verifica se o usuário foi encontrado
                {
                    emprestimos.Add(new Emprestimo { Id = emprestimoIdCounter++, LivroId = livroId, UsuarioId = usuarioId, DataEmprestimo = DateTime.Now }); //Adiciona um novo empréstimo à lista de empréstimos, utilizando o contador de ID para garantir que cada empréstimo tenha um ID único
                    livro.Disponivel = false; //Marca o livro como indisponível para empréstimo
                    Console.WriteLine("Empréstimo adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado ou indisponível para empréstimo.");
            }
        }

        private void ListarEmprestimoAtivos()
        {
            Console.WriteLine("\n ============ Empréstimos Ativos ============");

            var emprestimosAtivos = emprestimos.Where(e => e.DataDevolucao == null).ToList(); //Filtra a lista de empréstimos para obter apenas os empréstimos ativos (aqueles que ainda não foram devolvidos)

            foreach (var emprestimo in emprestimosAtivos) //foreach para percorrer a lista de empréstimos ativos e exibir as informações de cada empréstimo
            {
                var livro = livros.FirstOrDefault(l => l.Id == emprestimo.LivroId); //Busca o livro associado ao empréstimo

                var usuario = usuarios.FirstOrDefault(u => u.Id == emprestimo.UsuarioId); //Busca o usuário associado ao empréstimo

                Console.WriteLine($"ID: {emprestimo.Id} | Livro: {livro?.Titulo} | Usuário: {usuario?.Nome} | Data do Empréstimo: {emprestimo.DataEmprestimo.ToShortTimeString()}");
            }
        }

        private void DevolverLivro()
        {
            Console.WriteLine("\n ============ Devolver Livro ============");
            Console.WriteLine("ID do empréstimo a ser devolvido: ");
            int emprestimoId = int.Parse(Console.ReadLine());

            var emprestimo = emprestimos.FirstOrDefault(e => e.Id == emprestimoId); //Busca o empréstimo na lista de empréstimos com base no ID fornecido pelo usuário

            if (emprestimo != null && emprestimo.DataDevolucao == null) //Verifica se o empréstimo foi encontrado e ainda não foi devolvido
            {
                emprestimo.DataDevolucao = DateTime.Now; //Marca a data de devolução do empréstimo como a data atual

                var livro = livros.FirstOrDefault(l => l.Id == emprestimo.LivroId); //Busca o livro associado ao empréstimo

                if (livro != null)
                {
                    livro.Disponivel = true; //Marca o livro como disponível para empréstimo novamente
                }
                Console.WriteLine("Livro devolvido com sucesso!");
            }
            else
            {
                Console.WriteLine("Empréstimo não encontrado ou já devolvido.");
            }
        }

        private void HistoricoDeEmprestimoPorUsuario()
        {
            Console.WriteLine("\n ============ Histórico de Empréstimos por Usuário ============");
            Console.WriteLine("ID do usuário: ");
            int usuarioId = int.Parse(Console.ReadLine());

            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioId); //Busca o usuário na lista de usuários com base no ID fornecido pelo usuário

            if (usuario != null) //Verifica se o usuário foi encontrado
            {
                var historicoEmprestimos = emprestimos.Where(e => e.UsuarioId == usuarioId).ToList(); //Filtra a lista de empréstimos para obter apenas os empréstimos associados ao usuário

                Console.WriteLine($"Histórico de Empréstimos para {usuario.Nome}:");

                foreach (var emprestimo in historicoEmprestimos) //foreach para percorrer a lista de empréstimos do usuário e exibir as informações de cada empréstimo
                {
                    var livro = livros.FirstOrDefault(l => l.Id == emprestimo.LivroId); //Busca o livro associado ao empréstimo

                    string status = emprestimo.DataDevolucao == null ? "Ativo" : $"Devolvido em {emprestimo.DataDevolucao.Value.ToShortTimeString()}"; //Determina o status do empréstimo com base na data de devolução

                    Console.WriteLine($"ID: {emprestimo.Id} | Livro: {livro?.Titulo} | Data do Empréstimo: {emprestimo.DataEmprestimo.ToShortTimeString()} | Status: {status}");
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
    }
}
