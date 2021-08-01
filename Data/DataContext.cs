using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using CaixaEletronico.Models;

namespace CaixaEletronico.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Caixa> Caixas {get; set;}
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Conta> Contas {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Caixa>()
                    .HasData(new List<Caixa>() {
                        new Caixa() {DinheiroDisponivel = 10000, Data = "31/07/2021 08:00:00"},
                        new Caixa() {DinheiroDisponivel = 2000, Data = "31/07/2021 10:47:30"},
                        new Caixa() {DinheiroDisponivel = 3000, Data = "31/07/2021 12:35:02"},
                        new Caixa() {DinheiroDisponivel = 4000, Data = "31/07/2021 16:00:50"},
                        new Caixa() {DinheiroDisponivel = 5000, Data = "31/07/2021 22:00:00"}
                    });

            builder.Entity<Cliente>()
                    .HasData(new List<Cliente>() 
                    {
                        new Cliente() {Id = 1, Nome = "Maria Souza", Cpf = 0000001, Telefone = 99998888, ContaNumero = 101201},
                        new Cliente() {Id = 2, Nome = "Julia Pires", Cpf = 000002, Telefone = 99996666, ContaNumero = 101202},
                        new Cliente() {Id = 3, Nome = "Pedro Costa", Cpf = 000003, Telefone = 999995555, ContaNumero= 101203},
                        new Cliente() {Id = 4, Nome = "Paulo Abreu", Cpf = 000004, Telefone = 99997777, ContaNumero = 101204},
                        new Cliente() {Id = 5, Nome = "Ana da Silva", Cpf = 000005, Telefone = 99992222, ContaNumero = 101205}
                    });
            
            builder.Entity<Conta>()
                    .HasData(new List<Conta>() {
                        new Conta() {Numero = 101201, Senha = 123456, Saldo = 1000, ClienteId = 1},
                        new Conta() {Numero = 101202, Senha = 678901, Saldo = 500, ClienteId = 2},
                        new Conta() {Numero = 101203, Senha = 234567, Saldo = 2000, ClienteId = 3},
                        new Conta() {Numero = 101204, Senha = 890123, Saldo = 150, ClienteId = 4},
                        new Conta() {Numero = 101205, Senha = 456789, Saldo = 3000, ClienteId = 5}
                   });
        }
        
    }
}