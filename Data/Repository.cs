using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CaixaEletronico.Models;

namespace CaixaEletronico.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
              _context.Add(entity);
        }
         public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Cliente[]> GetAllClienteAsync()
        {
            IQueryable<Cliente> query = _context.Clientes;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteAsyncById(int clienteId)
        {
            IQueryable<Cliente> query = _context.Clientes;
            query = query.AsNoTracking()
                         .OrderBy(clientes => clientes.Id)
                         .Where(clientes => clientes.Id == clienteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Conta[]> GetAllContaAsync()
        {
            IQueryable<Conta> query = _context.Contas;
            query = query.AsNoTracking()
                         .OrderBy(c => c.Numero);

            return await query.ToArrayAsync();
        }

        public async Task<Conta> GetContaAsyncByNumero(int contaNumero)
        {
            IQueryable<Conta> query = _context.Contas;
            query = query.AsNoTracking()
                         .OrderBy(contas => contas.Numero)
                         .Where(contas => contas.Numero == contaNumero);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Caixa[]> GetAllCaixaAsync()
        {
            IQueryable<Caixa> query = _context.Caixas;
            query = query.AsNoTracking()
                         .OrderBy(c => c.DinheiroDisponivel);

            return await query.ToArrayAsync();
        }

        public async Task<Caixa> GetCaixaAsyncByDinheiro(decimal caixaDinheiroDisponivel)
        {
            IQueryable<Caixa> query = _context.Caixas;
            query = query.AsNoTracking()
                         .OrderBy(caixas => caixas.DinheiroDisponivel)
                         .Where(caixas => caixas.DinheiroDisponivel == caixaDinheiroDisponivel);

            return await query.FirstOrDefaultAsync();
        }
    }
}