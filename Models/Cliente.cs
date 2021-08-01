namespace CaixaEletronico.Models
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(int id, string nome, int cpf, int telefone, int contaNumero, Conta conta) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
            this.ContaNumero = contaNumero;
            this.Conta = conta;
               
        }

        public int Id {get; set;}
        public string Nome {get; set;}
        public int Cpf {get; set;}
        public int Telefone {get; set;}

        public int ContaNumero {get; set;}
        public Conta Conta {get; set;}
    }
}