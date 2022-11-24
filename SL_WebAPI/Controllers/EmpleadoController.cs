using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class EmpleadoController : ApiController
    {

        [HttpGet]
        [Route("api/Empleado/GetAll")]

        public IHttpActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Objects);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpGet]
        [Route("api/Estado/GetAll")]

        public IHttpActionResult GetAllEstado()
        {
            ML.Estado estado = new ML.Estado();
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Objects);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Empleado/Add")]

        public IHttpActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        //// GET: api/Empleado
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Empleado/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Empleado
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Empleado/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Empleado/5
        //public void Delete(int id)
        //{
        //}
    }
}
