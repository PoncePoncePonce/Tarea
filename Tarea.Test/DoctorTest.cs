using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Entidades;

namespace Tarea.Test
{
    public class DoctorTest
    {
        [Fact]
        public void DoctorCreateValidation_WhiteSpace()
        {
            var doctor = new Doctores();
            Assert.Throws<ArgumentException>("Cedula", () => doctor.Cedula = "123 567");
            Assert.Throws<ArgumentException>("NumeroDeTelefono", () => doctor.NumeroDeTelefono = "1234 67890");
        }



        [Fact]
        public void DoctorCreateValidation_CedulaLenght()
        {
            var doctor = new Doctores();
            Assert.Throws<ArgumentException>("Cedula", () => doctor.Cedula = "123456789012345678");
        }



        [Fact]
        public void DoctorCreateValidation_TelefonoLenght()
        {
            var doctor = new Doctores();
            Assert.Throws<ArgumentException>("NumeroDeTelefono", () => doctor.NumeroDeTelefono = "123456789012");
        }
    }
}
