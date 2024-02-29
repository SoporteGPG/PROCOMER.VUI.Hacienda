using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRUT.Entidades
{
    public class Apoderado
    {
        public string NroIdentificacion { get; set; }
        public int? CodTipoClasePersona { get; set; }
        public string NombreApoderado { get; set; }
        public int NroProvincia { get; set; }
        public string StrProvincia { get; set; }
        public int NroCanton { get; set; }
        public string StrCanton { get; set; }
        public int NroDistrito { get; set; }
        public string StrDistrito { get; set; }
        public string OtrasSenas { get; set; }
        public string Correo { get; set; }
        public string DetallePoder { get; set; }
        public string TelefonoMovil { get; set; }
        public DateTime? FechaInicio { get; set; }
    }
}