using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Entidades;

namespace Tarea.Test
{
    public class clienteTest
    {
        [Fact]
        public void ClienteCreateValidation_NotNullOrWhiteSpace()
        {
            var cliente = new Clientes();
            Assert.Throws<ArgumentException>("Nombre", () => cliente.Nombre = "");
            Assert.Throws<ArgumentException>("Apellido", () => cliente.Apellido = "");
        }



        [Fact]
        public void ClienteCreateValidation_NombreLength()
        {
            var cliente = new Clientes();
            Assert.Throws<ArgumentException>("Nombre", () => cliente.Nombre = "MA");
        }



        [Fact]
        public void ClienteCreateValidation_ApellidoLength()
        {
            var cliente = new Clientes();
            Assert.Throws<ArgumentException>("Apellido", () => cliente.Apellido = "IALOR");
        }
    }
}
