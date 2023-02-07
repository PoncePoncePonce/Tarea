﻿using Api_Consultorio.Modelos;
using Consultorio.Business.Entidades;
using Consultorio.Business.Interfaces.Repositorios;
using Consultorio.Business.Interfaces.Servicios;
using Consultorio.Business.Modelos;
using Consultorio.Business.Soportes;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Business.Servicios
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IConsultaRepository _consultaRepo;
        private readonly IDoctorRepository _repo;
        private readonly IMemoryCache _memoryCache;

        public DoctorServices(IDoctorRepository repo, IConsultaRepository consultaRepo,
        IClienteRepository clienteRepo)
        {
            this._repo = repo;
            _consultaRepo = consultaRepo;
            _clienteRepo = clienteRepo;
        }

        public Doctor ActualizarDoctor(string id, string cedula, string nombre, string apellido, string numCel)
        {
            var doctor = _repo.ConsultarPorId(id) ?? throw new ValidationException("No se encontro el Doctor");
            doctor.Cedula = cedula ?? doctor.Cedula;
            doctor.Nombre = nombre ?? doctor.Nombre;
            doctor.Apellido = apellido ?? doctor.Apellido;
            doctor.NumeroDeTelefono = numCel ?? doctor.NumeroDeTelefono;

            _repo.Actualizar(doctor);
            _repo.GuardarCambios();
            return doctor;
        }

        public Doctor AgregarDoctor(string cedula, string nombre, string apellido, string numCel)
        {
            var doctor = new Doctor()
            {
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido,
                NumeroDeTelefono = numCel
            };
            _repo.Agregar(doctor);
            _repo.GuardarCambios();
            return doctor;
        }

        public PagedList<Doctor> ConsultarDoctores(DoctorParameters doctorParameters)
        {
            var doctor = _memoryCache.Get<PagedList<Doctor>>("doctores");
            if (doctor == null)
            {
                doctor = _repo.Consultar(doctorParameters);
                _memoryCache.Set("doctores", doctor, TimeSpan.FromMinutes(1));
            }

            var metadata = new
            {
                doctor.TotalCount,
                doctor.PageSize,
                doctor.CurrentPage,
                doctor.HasNext,
                doctor.HasPrevious
            };

            return doctor;
        }
        public Doctor ConsultarDoctorPorId(string id)
        {
            var doctor = _repo.Consultar().Where(x => x.Id == id).FirstOrDefault();
            return doctor;
        }

        public Doctor EliminarDoctor(string id)
        {
            Doctor doctor = _repo.ConsultarPorId(id);
            if (doctor == null)
            {
                throw new ValidationException("Doctor no encontrado");
            }
            _repo.Eliminar(doctor);
            return doctor;
        }
    }
}
