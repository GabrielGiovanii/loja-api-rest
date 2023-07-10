using System;
using System.Web.Http;

namespace web_api.Controllers
{
    public class VeiculosController : ApiController
    {
        private Repositories.IRepository<Models.Veiculo> repository;

        public VeiculosController()
        {
            try{
                repository = new Repositories.Database.SQLServer.ADO.Veiculo
                    (Configurations.SQLServer.getConnectionString());
            }
            catch (Exception ex) {
                Logger.Log.write(ex, Configurations.Log.getFullPath());
            }
        }

        // GET: api/Veiculos
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.get());
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex,Configurations.Log.getFullPath());   
                return InternalServerError();
            }
        }

        // GET: api/Veiculos/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Veiculo veiculo = repository.getById(id);
                if (veiculo == null)
                    return NotFound();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getFullPath());
                return (InternalServerError());
            }
        }

        // POST: api/Veiculos
        public IHttpActionResult Post(Models.Veiculo veiculo)
        {
            try
                {
                if (veiculo.AnoModelo == 0)
                    ModelState.AddModelError("veiculo.AnoModelo", "AnoModelo é obrigatório.");

                DateTime dtStandard = new DateTime(1, 1, 1);
                if (veiculo.DataFabricacao == dtStandard)
                    ModelState.AddModelError("veiculo.DataFabricacao", "Data de fabricação é obrigatório.");

                if (veiculo.Valor == 0)
                    ModelState.AddModelError("veiculo.Valor", "Valor é obrigatório.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                repository.add(veiculo);

                return Ok();
            }
            catch (Exception ex) 
            {
                Logger.Log.write(ex, Configurations.Log.getFullPath());
                return InternalServerError();
            }
        }

        // PUT: api/Veiculos/5
        public IHttpActionResult Put(Models.Veiculo veiculo)
        {
            try
            {
                if (veiculo.Id == 0)
                    ModelState.AddModelError("veiculo.Id", "Id é obrigatório.");

                if (veiculo.AnoModelo == 0)
                    ModelState.AddModelError("veiculo.AnoModelo", "AnoModelo é obrigatório.");

                DateTime dt = new DateTime(1, 1, 1);
                if (veiculo.DataFabricacao == dt)
                    ModelState.AddModelError("veiculo.DataFabricacao", "Data de fabricação é obrigatório.");

                if (veiculo.Valor == 0)
                    ModelState.AddModelError("veiculo.Valor", "Valor é obrigatório.");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.update(veiculo);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok();
            }
            catch(Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getFullPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Veiculos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int linhasAfetadas = repository.delete(id);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok();
            }
            catch(Exception ex)
            {
                Logger.Log.write(ex, Configurations.Log.getFullPath());
                return InternalServerError();
            }
        }
    }
}
