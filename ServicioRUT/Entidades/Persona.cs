using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRUT.Entidades
{
    public class Persona
    {
        public string NroIdentificacion { get; set; }
        public int? CodTipoClasePersona { get; set; }
        public string NombreContribuyente { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Correo { get; set; }
        public int NroProvincia { get; set; }
        public string StrProvincia { get; set; }
        public int NroCanton { get; set; }
        public string StrCanton { get; set; }
        public int NroDistrito { get; set; }
        public string StrDistrito { get; set; }
        public string OtrasSenas { get; set; }
        public DateTime? FechaCierre { get; set; }
    }
}