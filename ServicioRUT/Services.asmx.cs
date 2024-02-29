using Newtonsoft.Json;
using PROCOMER.VUI.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace ServicioRUT
{
    /// <summary>
    /// Summary description for Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Services : System.Web.Services.WebService
    {

        
[WebMethod]
        public string RealizarInscripcionJson(string pm_RefBase, string pm_Ambiente)
        {
            SqlCommand cmdTabla = new SqlCommand();
            cls_Conexion objConexion = new cls_Conexion();

            WS_ServicesRUTPruebas.ProcomerReq Datos = new WS_ServicesRUTPruebas.ProcomerReq();// Almacena los datos par enviarlos al servicio
            List<WS_ServicesRUTPruebas.ProcomerReq> DatosEmpresa = new List<WS_ServicesRUTPruebas.ProcomerReq>(); //Almacena en crudo los datos de la base de datos 
            string json = "";
            //try
            //{
                SqlDataReader dr;
                cmdTabla.CommandType = CommandType.StoredProcedure;
                cmdTabla.CommandText = "sp_ConsultarInfo_RUT";
                cmdTabla.Connection = objConexion.m_ObtenerConexionAmbiente(pm_Ambiente);
                cmdTabla.Parameters.Add("@RefBase", SqlDbType.NVarChar).Value = pm_RefBase;
                dr = cmdTabla.ExecuteReader();
                while (dr.Read())
                {
                    WS_ServicesRUTPruebas.ProcomerReq request2 = new WS_ServicesRUTPruebas.ProcomerReq()
                    {
                        ActividadEconomica = new WS_ServicesRUTPruebas.ActividadEconomica()
                        {
                            CodigoActividad = dr["ActCodigoActividad"].ToString(),
                            NombreComercial = dr["ActNombreComercialRUT"].ToString(),
                            FechaInicio = dr["ActFechaInicioRUT"].ToString(),
                            TelefonoFijo = dr["ActTelefonoFijoPersonaRUT"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["ActNroProvincia"].ToString()),
                            StrProvincia = dr["ActStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["ActNroCanton"].ToString()),
                            StrCanton = dr["ActStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["ActNroDistrito"].ToString()),
                            StrDistrito = dr["ActStrDistrito"].ToString(),
                            OtrasSenas = dr["ActOtrasSenas"].ToString()
                        },
                        Apoderado = new WS_ServicesRUTPruebas.Apoderado()
                        {
                            NroIdentificacion = dr["ApdNroIdentificacion"].ToString(),
                            CodTipoClasePersona = dr["ApdCodTipoClasePersona"].ToString(),
                            NombreApoderado = dr["ApdNombreApoderado"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["ApdNroProvincia"].ToString()),
                            StrProvincia = dr["ApdStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["ApdNroCanton"].ToString()),
                            StrCanton = dr["ActStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["ApdNroDistrito"].ToString()),
                            StrDistrito = dr["ApdStrDistrito"].ToString(),
                            OtrasSenas = dr["ApdOtrasSenas"].ToString(),
                            Correo = dr["ApdCorreo"].ToString(),
                            DetallePoder = dr["ApdDetallePoder"].ToString(),
                            TelefonoMovil = dr["ApdTelefonoMovil"].ToString(),
                            FechaInicio = dr["ApdFechaInicio"].ToString()
                        },
                        Persona = new WS_ServicesRUTPruebas.Persona()
                        {
                            NroIdentificacion = dr["PerNroIdentificacion"].ToString(),
                            CodTipoClasePersona = dr["PerCodTipoClasePersona"].ToString(),
                            NombreContribuyente = dr["PerNombreContribuyente"].ToString(),
                            TelefonoFijo = dr["PersonaTelefonoFijo"].ToString(),
                            TelefonoMovil = dr["PersonaTelefonoMovilRUT"].ToString(),
                            Correo = dr["PersonaCorreoRUT"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["PerNroProvincia"].ToString()),
                            StrProvincia = dr["PerStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["PerNroCanton"].ToString()),
                            StrCanton = dr["PerStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["PerNroDistrito"].ToString()),
                            StrDistrito = dr["PerStrDistrito"].ToString(),
                            OtrasSenas = dr["PerOtrasSenas"].ToString(),
                            FechaCierre = dr["PersonaFechaCierre"].ToString()
                        },
                        Representante = new WS_ServicesRUTPruebas.Representante
                        {
                            NumIdentificacion = dr["RepNumIdentificacion"].ToString(),
                            CodTipoClasePersona = dr["RepCodTipoClasePersona"].ToString(),
                            StrNombreRepresentante = dr["RepStrNombreRepresentante"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["RepNroProvincia"].ToString()),
                            StrProvincia = dr["RepStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["RepNroCanton"].ToString()),
                            StrCanton =dr["RepStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["RepNroDistrito"].ToString()),
                            StrDistrito = dr["RepNroDistrito"].ToString(),
                            OtrasSenas = dr["RepOtrasSenas"].ToString(),
                            Correo = dr["RepCorreo"].ToString(),
                            DetalleRepresentacion = dr["RepDetalleRepresentacion"].ToString(),
                            TelefonoMovil = dr["RepTelefonoMovil"].ToString(),
                            FechaInicio = dr["RepFechaInicio"].ToString(),
                        }                     
                    };
                    Datos = request2;
                }
                json = JsonConvert.SerializeObject(Datos);

                WS_ServicesRUTPruebas.IInscripcionRUT rut = new WS_ServicesRUTPruebas.InscripcionRUTClient();

                rut.RealizaInscripcionJson("");
            //}
            //catch (Exception ex)
            //{

            //}
            return json;
        }

    }
}
