using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BitHead.SweetHome.WebAPI.Controllers
{
    public class ImoveisController : ApiController
    {
        //GET api/<controller>
        public async Task<HttpResponseMessage> Get()
        {
            var imoveis = await new Shared.Repos.Imovel().GetImoveisAsync();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(imoveis))
            };
        }

        // GET api/<controller>/5
        public async Task<HttpResponseMessage> Get(Guid id)
        {
            var imovel = await new Shared.Repos.Imovel().GetImovelAsync(id);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(imovel))
            };
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post([FromBody]Shared.Database.Imoveis imovel)
        {
            try
            {
                await new Shared.Repos.Imovel().AddImovelAsync(imovel);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception erro)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(erro.Message)
                };
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}