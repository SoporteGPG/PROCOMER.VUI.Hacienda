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
            string json = "";
            string retorna = "";
            string mensaje = "";

            try
            {
                SqlDataReader dr;
                cmdTabla.CommandType = CommandType.StoredProcedure;
                cmdTabla.CommandText = "sp_ConsultarInfo_RUT";
                cmdTabla.Connection = objConexion.m_ObtenerConexionAmbiente();
                cmdTabla.Parameters.Add("@RefBase", SqlDbType.NVarChar).Value = pm_RefBase;
                dr = cmdTabla.ExecuteReader();
                while (dr.Read())//Lectura de los datos basandode en la consulta
                {
                    WS_ServicesRUTPruebas.ProcomerReq request = new WS_ServicesRUTPruebas.ProcomerReq()//instancia de objeto de la clase que viene en el servicio
                    {
                        ActividadEconomica = new WS_ServicesRUTPruebas.ActividadEconomica()//subclase de servicio
                        {
                            CodigoActividad = dr["3_ActCodigoActividad"].ToString(),
                            NombreComercial = dr["3_Nombre comercial RUT"].ToString(),
                            FechaInicio = dr["3_Fecha inicio RUT"].ToString(),
                            TelefonoFijo = dr["3_Teléfono fijo persona RUT"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["3_ActNroProvincia"].ToString()),
                            StrProvincia = dr["3_ActStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["3_ActNroCanton"].ToString()),
                            StrCanton = dr["3_ActStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["3_ActNroDistrito"].ToString()),
                            StrDistrito = dr["3_ActStrDistrito"].ToString(),
                            OtrasSenas = dr["3_ActOtrasSenas"].ToString()
                        },
                        Apoderado = new WS_ServicesRUTPruebas.Apoderado()//subclase de servicio
                        {
                            NroIdentificacion = dr["3_ApdNroIdentificacion"].ToString(),
                            CodTipoClasePersona = dr["3_ApdCodTipoClasePersona"].ToString(),
                            NombreApoderado = dr["3_ApdNombreApoderado"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["3_ApdNroProvincia"].ToString()),
                            StrProvincia = dr["3_ApdStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["3_ApdNroCanton"].ToString()),
                            StrCanton = dr["3_ApdStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["3_ApdNroDistrito"].ToString()),
                            StrDistrito = dr["3_ApdStrDistrito"].ToString(),
                            OtrasSenas = dr["3_ApdOtrasSenas"].ToString(),
                            Correo = dr["3_ApdCorreo"].ToString(),
                            DetallePoder = dr["3_ApdDetallePoder"].ToString(),
                            TelefonoMovil = dr["3_ApdTelefonoMovil"].ToString(),
                            FechaInicio = dr["3_ApdFechaInicio"].ToString()
                        },
                        Persona = new WS_ServicesRUTPruebas.Persona()//subclase de servicio
                        {
                            NroIdentificacion = dr["3_PerNroIdentificacion"].ToString(),
                            CodTipoClasePersona = dr["3_PerCodTipoClasePersona"].ToString(),
                            NombreContribuyente = dr["3_PerNombreContribuyente"].ToString(),
                            TelefonoFijo = dr["3_PersonaTelefonoFijo"].ToString(),
                            TelefonoMovil = dr["3_Persona teléfono movil RUT"].ToString(),
                            Correo = dr["3_Persona correo RUT"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["3_PerNroProvincia"].ToString()),
                            StrProvincia = dr["3_PerStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["3_PerNroCanton"].ToString()),
                            StrCanton = dr["3_PerStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["3_PerNroDistrito"].ToString()),
                            StrDistrito = dr["3_PerStrDistrito"].ToString(),
                            OtrasSenas = dr["3_PerOtrasSenas"].ToString(),
                            FechaCierre = dr["3_PersonaFechaCierre"].ToString()
                        },
                        Representante = new WS_ServicesRUTPruebas.Representante//subclase de servicio
                        {
                            NumIdentificacion = dr["3_RepNumIdentificacion"].ToString(),
                            CodTipoClasePersona = dr["3_RepCodTipoClasePersona"].ToString(),
                            StrNombreRepresentante = dr["3_RepStrNombreRepresentante"].ToString(),
                            NroProvincia = (short)Convert.ToInt32(dr["3_RepNroProvincia"].ToString()),
                            StrProvincia = dr["3_RepStrProvincia"].ToString(),
                            NroCanton = (short)Convert.ToInt32(dr["3_RepNroCanton"].ToString()),
                            StrCanton = dr["3_RepStrCanton"].ToString(),
                            NroDistrito = (short)Convert.ToInt32(dr["3_RepNroDistrito"].ToString()),
                            StrDistrito = dr["3_RepStrDistrito"].ToString(),
                            OtrasSenas = dr["3_RepOtrasSenas"].ToString(),
                            Correo = dr["3_RepCorreo"].ToString(),
                            DetalleRepresentacion = dr["3_RepDetalleRepresentacion"].ToString(),
                            TelefonoMovil = dr["3_RepTelefonoMovil"].ToString(),
                            FechaInicio = dr["3_RepFechaInicio"].ToString(),
                        }
                    };
                    Datos = request;
                }
                objConexion.m_ObtenerConexionAmbiente().Close();
                json = JsonConvert.SerializeObject(Datos);//serializacion de objeto a json

                //se consulta al servicio para realizar la inscripcion en formato json
                WS_ServicesRUTPruebas.IInscripcionRUT rut = new WS_ServicesRUTPruebas.InscripcionRUTClient();
                var respuestaJson = rut.RealizaInscripcionJson(json);

                //se realiza la inscripcion, en este campo utilizando el metodo RealizarInscripción
                WS_ServicesRUTPruebas.ProcomerRes respuesta = new WS_ServicesRUTPruebas.ProcomerRes();
                respuesta = rut.RealizaInscripcion(Datos);

                //WS_ServicesRUTPruebas.IInscripcionRUT respuesta = new WS_ServicesRUTPruebas.InscripcionRUTClient();
                //resp.RealizaInscripcion(Datos);

                retorna = JsonConvert.SerializeObject(respuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorna;
        }

    }
}
