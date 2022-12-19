﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea.Transversal.Guards
{
    public static class Guard
    {
        #region Metodos de Extension
        public static string HasValue(this string value, string property)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre del Cliente debe contener un valor", property);
            }
            return value;
        }
        public static string GreaterThan(this string value, int min, string property)
        {
            if (value.Length <= min)
            {
                throw new ArgumentException(
                    $"El nombre del Cliente debe ser mayo a {min} caracteres",
                    property);
            }

            return value;
        }
        //checa si el valor es menor a 
       public static string LowerThan(this string value, int max, string property)
        {
            if(value.Length >= max)
            {
                throw new ArgumentException(
                    $"El nombre del Cliente debe ser menor a {max} caracteres",
                    property);
            }
            return value;
        }
        //checa si el valor es igual a
        public static string EqualsNumber(this string value, int equal, string property)
        {
            if (value.Length != equal)
            {
                throw new ArgumentException($"Debe contener {equal} caracteres", property);
            }
            return value;
        }
        //checa si el string tiene espacios en blanco
        public static string HasWhiteSpace(this string value, string property)
        {
            if(value.Contains(" "))
            {
                throw new ArgumentException("No debe llevar estacios en blanco", property);
            }
            return value;
        }
        //checa si el string esta compuesto solo por numeros
        public static string IsNumber(this string value, string property)
        {
            int isNumber;
            if(int.TryParse(value, out isNumber) == false)
            {
                throw new ArgumentException("Solo debe contener numeros", property);
            }
            return value;
        }
        #endregion

        #region Metodos Estaticos
        public static class Against
        {
            public static string NotNull(string value, string property)
            {
                if (String.IsNullOrWhiteSpace(value) && value.Length > 2)
                {
                    throw new ArgumentException("El nombre del Cliente debe contener un valor", property);
                }
                return value;
            }
            public static string GreaterThan(string value, int min, string property)
            {
                if (value.Length < min)
                {
                    throw new ArgumentException(
                        $"El nombre del Cliente debe ser mayo a {min} caracteres",
                        property);
                }
                return value;
            }
        }
        #endregion
    }
}
