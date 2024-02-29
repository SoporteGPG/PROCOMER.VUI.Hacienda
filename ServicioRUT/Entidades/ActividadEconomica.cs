using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRUT.Entidades
{
    public class ActividadEconomica
    {
        public int? CodigoActividad { get; set; }
        public string NombreComercial { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string TelefonoFijo { get; set; }
        public int NroProvincia { get; set; }
        public string StrProvincia { get; set; }
        public int NroCanton { get; set; }
        public string StrCanton { get; set; }
        public int NroDistrito { get; set; }
        public string StrDistrito { get; set; }
        public string OtrasSenas { get; set; }
    }
}