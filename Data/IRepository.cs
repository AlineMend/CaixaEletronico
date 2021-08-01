using System.Collections.Generic;
using System.Threading.Tasks;
using CaixaEletronico.Models;

namespace CaixaEletronico.Data
{
    public interface IRepository
    {
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class; 
        Task<bool> SaveChangesAsync();

        Task<Cliente[]> GetAllClienteAsync();        
        Task<Cliente> GetClienteAsyncById(int clienteId);
        
        
        Task<Conta[]> GetAllContaAsync();
        Task<Conta> GetContaAsyncByNumero(int contaNumero);
        Task<Caixa[]> GetAllCaixaAsync();

        Task<Caixa> GetCaixaAsyncByDinheiro(decimal caixaDinheiroDisponivel);

        
    }
}