using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;

namespace BlogArticulos.WebService.Validadores
{
    public class RespuestaServer
    {
        public string TipoRespuesta { get; set; }
        public string Mensaje { get; set; }
        public object Resultado { get; set; }

        private JavaScriptSerializer _oSerializer;

        public RespuestaServer()
        {
            _oSerializer = new JavaScriptSerializer();
        }

        public string SerializarAJson(object ObjetoAJson, TipoRespuestaServer tipoRespuesta = TipoRespuestaServer.OK, string mensaje = "")
        {
            return _oSerializer.Serialize(new RespuestaServer()
            {
                TipoRespuesta = tipoRespuesta.ToString(),
                Mensaje = mensaje,
                Resultado = ObjetoAJson
            });
        }
    }

    public enum TipoRespuestaServer :int
    {
        FOULT = 0,
        OK = 1
    }
}