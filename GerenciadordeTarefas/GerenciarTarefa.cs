using System;
using System.Collections.Generic;
using Layout;
using Tarefas;

namespace GerenciarTarefa
{
    public static class Gerenciador
    {
        private static List<Tarefa> listaTarefas = new List<Tarefa>();
        private static int contadorId = 1;

        public static void AdicionarTarefa(string descricao)
        {
            listaTarefas.Add(new Tarefa(contadorId++, descricao));
            Formatacao.Cor("Tarefa adicionada com sucesso!", ConsoleColor.Green);
        }

        public static void ListarTarefa()
        {
            Formatacao.Cor("Lista de tarefas:", ConsoleColor.Yellow);
            foreach (var tarefa in listaTarefas)
            {
                tarefa.ExibirTarefa();
            }
        }

        public static void ConcluirTarefa(int id)
        {
            var tarefa = listaTarefas.Find(t => t.Id == id);
            if (tarefa != null)
            {
                tarefa.Concluida = true;
                Formatacao.Cor("Tarefa concluída!", ConsoleColor.Green);
            }
            else
            {
                Formatacao.Cor("Tarefa não encontrada!", ConsoleColor.Red);
            }
        }

        public static void RemoverTarefa(int id)
        {
            var tarefa = listaTarefas.Find(t => t.Id == id);
            if (tarefa != null)
            {
                listaTarefas.Remove(tarefa);
                Formatacao.Cor("Tarefa removida com sucesso!", ConsoleColor.Red);
            }
            else
            {
                Formatacao.Cor("Tarefa não encontrada!", ConsoleColor.Red);
            }
        }

        public static void ExibirMenu()
        {
            while (true)
            {
                Formatacao.ImprimirCabecalho();
                Console.WriteLine("1 - Adicionar Tarefa");
                Console.WriteLine("2 - Listar Tarefas");
                Console.WriteLine("3 - Concluir Tarefa");
                Console.WriteLine("4 - Remover Tarefa");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                
                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite a descrição da tarefa: ");
                        string descricao = Console.ReadLine();
                        AdicionarTarefa(descricao);
                        break;

                    case "2":
                        ListarTarefa();
                        break;

                    case "3":
                        Console.Write("Digite o ID da tarefa a concluir: ");
                        if (int.TryParse(Console.ReadLine(), out int idConcluir))
                            ConcluirTarefa(idConcluir);
                        break;

                    case "4":
                        Console.Write("Digite o ID da tarefa a remover: ");
                        if (int.TryParse(Console.ReadLine(), out int idRemover))
                            RemoverTarefa(idRemover);
                        break;

                    case "0":
                        Formatacao.Cor("Saindo...", ConsoleColor.Red);
                        return;

                    default:
                        Formatacao.Cor("Opção inválida!", ConsoleColor.Red);
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}