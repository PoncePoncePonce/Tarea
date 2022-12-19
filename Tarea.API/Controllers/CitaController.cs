using Microsoft.AspNetCore.Mvc;
using Tarea.Business.Entidades;
using Tarea.Infraestructura.SQL.SQL_Server.Contextos;
using System.Linq;

namespace Tarea.API.Controllers
{
    [ApiController]
    [Route("api/v1/citas")]
    public class CitaController : ControllerBase
    {

        private readonly SQLContext _context;

        public CitaController(SQLContext sQLContext)
        {
            _context = sQLContext;
        }

        [HttpGet()]
        public ActionResult ConsultarCitas()
        {
            var citas = _context.Citas.ToList();

            return Ok(citas);
        }

        [HttpGet("{id}")]
        public ActionResult ConsultarCitas([FromRoute] string id)
        {
            Citas cita = _context.Citas.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return cliente;
                if (cita == null)
                {
                    return NotFound("Cita no encontrada");
                }



                return Ok(cita);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cita
                    });
            }

        }

        [HttpPost()]
        public ActionResult CrearCita([FromBody] Citas cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();

            return Ok(cita);
        }

        [HttpPut()]
        public ActionResult ActualizarConsulta([FromBody] string id)
        {
            Citas cita = _context.Citas.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return consulta;
                if (cita == null)
                {
                    return NotFound("Cliente no encontrado");
                }


                _context.Update(cita);
                return Ok(cita);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cita
                    });
            }
        }



        //Eliminar una consulta
        [HttpDelete("{id}")]///////NO TERMINADO
        public ActionResult EliminarCliente([FromBody] string id)
        {
            Citas cita = _context.Citas.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return consulta;
                if (cita == null)
                {
                    return NotFound("Cliente no encontrado");
                }
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cita
                    });
            }
            _context.Remove(cita);
            return Ok(cita);
        }


    }
}
