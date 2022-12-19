using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Entidades;
using Tarea.Business.Interfaces;

namespace Tarea.Infraestructura.SQL.SQL_Server.Repositorios
{
    public class DoctorSQLRepository : Repository<Doctores>, IDoctoresRepository
    {
        public DoctorSQLRepository(DbContext context) : base(context)
        {
        }
    }
}
