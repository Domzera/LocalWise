using LocalWise.Data;
using LocalWise.Interfaces;
using LocalWise.Models;
using LocalWise.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocalWise.Repository
{
    public class AccountRepository : IAccountRepository//Aqui o IGuiaRepository está sendo implementado
    {
        private readonly SignInManager<Pessoa> _signInManager;
        private LWDbContext _context;

        public AccountRepository(LWDbContext context, SignInManager<Pessoa> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public bool Add(Pessoa pessoa)
        {
            _signInManager.UserManager.CreateAsync(pessoa);
            //_context.Add(guia);
            return Save();
        }

        public bool Delete(Pessoa pessoa)
        {
            _signInManager.UserManager.DeleteAsync(pessoa);
            //_context.Remove(guia);
            return Save();
        }

        public bool Update(Pessoa pessoa)
        {
            _signInManager.UserManager.UpdateAsync(pessoa);
            //_context.Update(guia);
            return Save();
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            //return await _context.Guias.Include(t=>t.Pessoa).ToListAsync();
            return await _signInManager.UserManager.Users.ToListAsync();

        }

        public async Task<IEnumerable<Pessoa>> API_GetAll()
        {
         var us =  await _signInManager.UserManager.Users.Select(
                u => new Pessoa
                {
                    Email = u.Email,
                    DataCadastro = u.DataCadastro,
                    UserName = u.UserName
                }
                ).ToListAsync();

            return us;
        }

        public async Task<Pessoa> GetByIdAsync(string id)
        {
            //return await _context.Guias.FirstOrDefaultAsync(i => i.Id == id);
            return await _signInManager.UserManager.FindByIdAsync(id);
        }

        public async Task<Pessoa> GetByNameAsync(string name)
        {
            //return await _context.Guias.FirstOrDefaultAsync(n => n.Pessoa.UserName.Contains(name));
            return await _signInManager.UserManager.FindByNameAsync(name);
        }

        /*public async Task<IEnumerable<Pessoa>> GetGuiaByCity(string city)
        {
            //CONFERIR ESSE! INCLUIR I INCLUDE
            //return await _context.Guias.Include(i=>i.Id==id) .Where(c=>c.GerenteLocal.Endereco.Cidade.Contains(city)).ToListAsync();
        }*/

        public bool Save()
        {
            var saved = _context.SaveChanges();
            //var saved = _signInManager.UserManager.Users.
            return saved > 0 ? true : false;
        }


    }
}
