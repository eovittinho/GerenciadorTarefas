using System;

namespace Tarefas
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Concluida = false;
        }

        public void ExibirTarefa()
        {
            string status = Concluida ? "[X]" : "[ ]";
            Console.WriteLine($"{status} ID: {Id} - {Descricao}");
        }
    }
}