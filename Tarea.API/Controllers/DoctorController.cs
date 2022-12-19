using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tarea.Business.Entidades;
using Tarea.Infraestructura.SQL.SQL_Server.Contextos;

namespace Tarea.API.Controllers
{
    [ApiController]
    [Route("api/v1/doctores")]
    public class DoctorController : ControllerBase
    {
        private readonly SQLContext _context;

        public DoctorController(SQLContext sQLContext)
        {
            _context = sQLContext;
        }

        [HttpGet()]
        public ActionResult ConsultarDoctores()
        {
            var Doctores = _context.Doctores.ToList();

            return Ok(Doctores);
        }

        [HttpGet("{id}")]
        public ActionResult ConsultarDoctores([FromRoute] string id)
        {
            Doctores doctor = _context.Doctores.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                //return cliente;
                if (doctor == null)
                {
                    return NotFound("Doctor no encontrado");
                }



                return Ok(doctor);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Doctor no fue procesado",
                        Data = doctor
                    });
            }

        }

        [HttpPost()]
        public ActionResult CrearDoctor([FromBody] Doctores doctor)
        {
            _context.Doctores.Add(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }



    }
}

