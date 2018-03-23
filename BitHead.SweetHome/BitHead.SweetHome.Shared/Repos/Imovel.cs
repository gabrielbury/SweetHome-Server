using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHead.SweetHome.Shared.Repos
{
    public class Imovel
    {
        public async Task<bool> AddImovelAsync(Database.Imoveis imovel)
        {
            try
            {
                using (var ctx = new Database.SweetHomeEntities())
                {
                    ctx.Imoveis.Add(imovel);
                    await ctx.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception erro)
            {
                var idErro = Guid.NewGuid();
                //TODO: Log mensagem de erro
                throw new Exception("Ocorreu um problema ao adicionar o imóvel. cod: " + idErro);
            }
        }

        public async Task<IEnumerable<Database.Imoveis>> GetImoveisAsync()
        {
            try
            {
                using (var ctx = new Database.SweetHomeEntities())
                {
                    return await Task.FromResult(ctx.Imoveis.ToList());
                }
            }
            catch (Exception erro)
            {
                var idErro = Guid.NewGuid();
                //TODO: Log mensagem de erro
                throw new Exception("Ocorreu um problema ao recuperar a lista de imóveis. cod: " + idErro);
            }
        }

        public async Task<Database.Imoveis> GetImovelAsync(Guid id)
        {
            try
            {
                using (var ctx = new Database.SweetHomeEntities())
                {
                    return await ctx.Imoveis.FindAsync(id);
                }
            }
            catch (Exception erro)
            {
                var idErro = Guid.NewGuid();
                //TODO: Log mensagem de erro
                throw new Exception("Ocorreu um problema ao recuperar a lista de imóveis. cod: " + idErro);
            }
        }
    }
}
