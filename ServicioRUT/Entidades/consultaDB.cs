using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioRUT.Entidades
{
    public class consultaDB
    {
        public ActividadEconomica ActividadEconomica { get; set; }
        public Apoderado Apoderado { get; set; }
        public Persona Persona { get; set; }
        public Representante Representante { get; set; }

    }
}