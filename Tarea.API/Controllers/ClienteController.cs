using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Tarea.Business.Entidades;
using Tarea.Business.Interfaces;
using Tarea.Infraestructura.SQL.SQL_Server.Contextos;

namespace Tarea.API.Controllers
{

    [ApiController]
    [Route("api/v1/clientes")]
    public class ClienteController : ControllerBase
    {
        //private readonly SQLContext _context;
        //public ClienteController(SQLContext sQLContext)
        //{
        //    _context = sQLContext;
        //}

        private readonly IClientesRepository _repo;
        private readonly ILogger<ClienteController> logger;

        public ClienteController(IClientesRepository repo, ILogger<ClienteController> logger)
        {
            _repo = repo;
            this.logger = logger;
        }

        [HttpPost()]
        public ActionResult CrearCliente([FromBody] Clientes cliente)
        {
            _repo.Agregar(cliente);
            _repo.GuardarCambios();

            return Ok(cliente);
        }

        [HttpGet]
        public ActionResult consultarCliente()
        {
            var cliente = _repo.Consultar();
            return Ok(cliente);
        }
        [HttpGet("{Id}")]
        public ActionResult ConsultarCliente([FromRoute] string id)
        {
            Clientes cliente = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();//Todo: Refactorizar
            try
            {
                //return cliente;
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }



                return Ok(cliente);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cliente
                    });
            }

        }

        //Actualizar una consulta
        [HttpPut("{Id}")]
        public ActionResult ActualizarCliente([FromBody] string id)
        {
            Clientes cliente = _repo.ConsultarPorId(id);
            try
            {
                //return consulta;
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                return Ok(cliente);
            }
            catch
            {
                return StatusCode(500,
                    new
                    {
                        Error = "410025",
                        Mensaje = "Error: Cliente no fue procesado",
                        Data = cliente
                    });
            }

            return Ok(cliente);
        }

        //Eliminar una consulta
        [HttpDelete("{Id}")]
        public ActionResult EliminarCliente([FromBody] string id)
        {
            Clientes cliente = _repo.ConsultarPorId(id);
            try
            {
                //return consulta;
                if (cliente == null)
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
                        Data = cliente
                    });
            }
            //Todo: Crear metodo Eliminar
            /*
             * Crear el metodo en el IRepository
             * Crear la funcionalida en Repository
             * Guardar Cambios
             * */
            //_context.Remove(cliente);
            return Ok(cliente);
        }
        //[HttpGet()]
        //public ActionResult ConsultarClientes()
        //{
        //    var Clientes = _context.Clientes.ToList();

        //    return Ok(Clientes);
        //}

        //[HttpGet("{id}")]
        //public ActionResult ConsultarClientes([FromRoute] string id)
        //{
        //    Clientes cliente = _context.Clientes.Where(x => ((Business.Interfaces.IEntity)x).Id == id).FirstOrDefault();
        //    try
        //    {
        //        //return cliente;
        //        if (cliente == null)
        //        {
        //            return NotFound("Cliente no encontrado");
        //        }
        //        return Ok(cliente);
        //    }
        //    catch
        //    {
        //        return StatusCode(500,
        //            new
        //            {
        //                Error = "410025",
        //                Mensaje = "Error: Cliente no fue procesado",
        //                Data = cliente
        //            });
        //    }

        //}

        //[HttpPost()]
        //public ActionResult CrearCliente([FromBody] Clientes cliente)
        //{
        //    _context.Clientes.Add(cliente);
        //    _context.SaveChanges();

        //    return Ok(cliente);
        //}
    }

}