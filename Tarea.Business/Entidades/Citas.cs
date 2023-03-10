using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea.Business.Interfaces;

namespace Tarea.Business.Entidades
{
    public class Citas: IEntity

    {
        public readonly IRepository<Citas> repository;

        private readonly string path = "C:\\Users\\martin.ponce\\Documents\\prueba\\citas.csv";
        public string Id { get; set; }
        public string Doctor { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public Doctores Doctores { get; set; }
        public Clientes Clientes { get; set; }

        public string clienteId { get; set; }
        public string doctorId { get; set; }
        public Citas()
        {
        }
        public Citas(string Doctor, string Cliente, DateTime Fecha)
        {
            this.Doctor = Doctor;
            this.Cliente = Cliente;
            this.Fecha = Fecha;
        }
        public override string ToString()
        {
            return $"{Doctor},{Cliente},{Fecha}";
        }
        public void Agregar_Cita()
        {

            Citas cita = new Citas()
            {
                Id = Guid.NewGuid().ToString(),
                Doctor = Doctor,
                Cliente = Cliente,
                Fecha = Fecha,
            };

            Agregar_Cita(cita);

        }
        public void Agregar_Cita(Citas cita)
        {
            if (string.IsNullOrEmpty(Doctor) || string.IsNullOrEmpty(Cliente))
            {
                throw new ArgumentException("Los valores no deben estar vacios");
            }
            using (StreamWriter strWriter = new StreamWriter(path, true))
            {

                strWriter.WriteLine(cita.ToString());
                strWriter.Close();
            }
        }
        public List<Citas> Cargar_Citas()
        {
            List<Citas> ListaCitas = new();

            if (File.Exists(path))
            {
                /*Leer archivo*/
                using (StreamReader strReader = new StreamReader(path))
                {
                    string ln = string.Empty;

                    while ((ln = strReader.ReadLine()) != null)
                    {
                        string[] campos = ln.Split(",");

                        Citas cita = new()
                        {
                            Doctor = campos[0],
                            Cliente = campos[1],
                            Fecha = DateTime.Parse(campos[2]),
                        };
                        ListaCitas.Add(cita);
                    }
                }
            }
            return ListaCitas;
        }
        public void GuardarListaCitas(List<Citas> ListaCitas)
        {
            foreach (Citas cita in ListaCitas)
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    strWriter.WriteLine(cita.ToString());
                    strWriter.Close();
                }

            }
        }
        public Citas(IRepository<Citas> repository, string DoctorId, string ClienteId, DateTime fecha_consulta, string motivo)
        {
            this.repository = repository;
            //nomDoctor = nom_doctor;
            //nomCliente = nom_cliente;
            Fecha = fecha_consulta;
        }
    }
}
