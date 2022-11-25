using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SL_WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:16942", headers: "*", methods: "*")]
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

        [HttpGet]
        [Route("api/Empleado/GetById")]

        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Empleado/Update")]
        public IHttpActionResult Put(int IdEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.IdEmpleado = IdEmpleado;
            ML.Result result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int IdEmpleado)
        {

            ML.Empleado empleado = new ML.Empleado();
            empleado.IdEmpleado = IdEmpleado;
            var result = BL.Empleado.Delete(empleado);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
