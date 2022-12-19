using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Entidades;
using Tarea.Business.Interfaces;
using Tarea.Infraestructura.SQL.SQL_Server.Contextos;
using Tarea.Infraestructura.SQL.SQL_Server.Repositorios;

namespace Tarea.Infraestructura.SQLServer.SQL_Server.Repositorios
{
    public class CitaSQLRepository: Repository<Citas>, ICitaRepository
    {
        public CitaSQLRepository(SQLContext context) : base(context)
        {

        }
        public IEnumerable<Citas> ConsultarCitasPrevias(string DoctorId)
        {
            throw new NotImplementedException();
        }
    }
}
