namespace CaixaEletronico.Models
{
    public class Conta
    {
        public Conta()
        {
        }

        public Conta(int numero, int senha, decimal saldo, int clienteId, Cliente cliente) 
        {
            this.Numero = numero;
            this.Senha = senha;
            this.Saldo = saldo;
            this.ClienteId = clienteId;
            this.Cliente = cliente;
               
        }
        public int Numero {get; set;}
        public int Senha {get; set;}
        public decimal Saldo {get; set;}

        public int ClienteId {get; set;}
        public Cliente Cliente {get; set;}

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public bool Sacar (decimal valor)
        {
            if(Saldo - valor < 0)
            {
                return false;
            }
            Saldo -= valor;
            return true;
        }
        public bool Transferir(Conta destino, decimal valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }
            return false;
        }
    }
}