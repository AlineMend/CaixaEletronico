using System;
using System.Dynamic;
using System.Collections.Generic;
using CaixaEletronico.Models;


namespace CaixaEletronico.Models
{
    public class Caixa
    {

        public Caixa()
        {
        }

        public decimal DinheiroDisponivel {get; set;}
        public string Data {get; set;}
        
        public IEnumerable<Conta> Conta {get; set;}

         public void Adicinar(decimal dinheiroDisponivel)
        {
            DinheiroDisponivel = dinheiroDisponivel;
            var dataAgora = DateTime.Now;
            Data = String.Format("{0:yyyy/MM/dd}", dataAgora);
        }

         public void Depositar(decimal valor)
        {
            DinheiroDisponivel += valor;
        }

        public bool Sacar (decimal valor)
        {
            if(DinheiroDisponivel - valor < 0)
            {
                return false;
            }
            DinheiroDisponivel -= valor;
            return true;
        }

    }
}