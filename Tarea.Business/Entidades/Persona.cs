using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Interfaces;
using Tarea.Transversal.Guards;

namespace Tarea.Business.Entidades
{
    public abstract class Persona : IEntity
    {
        private string _nombre;
        private string _apellido;
        public string Id { get;  set; }
        public string Nombre
        {
            get => _nombre; set => _nombre = value
                .HasValue(nameof(Nombre))
                .GreaterThan(2, nameof(Nombre));
        }
        public string Apellido { 
            get => _apellido; 
            set => _apellido = value.HasValue(nameof(Apellido)).GreaterThan(5, nameof(Apellido)); }
    }
}
