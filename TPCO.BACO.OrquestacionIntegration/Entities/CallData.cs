namespace TPCO.BACO.OrquestacionIntegration.Entities
{
    public class CallData
    {
        /// <summary>
        /// Identificativo unico de la llamada
        /// </summary>
        public string UCID { get; set; }

        /// <summary>
        /// Token Oauth generado en la autenticacion de Bancolombia
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Tipo de documento del cliente
        /// </summary>
        public string TipoDocumento { get; set; }

        /// <summary>
        /// Numero de documento del cliente
        /// </summary>
        public string Documento { get; set; }

        /// <summary>
        /// Indica el metodo de autenticacion del cliente (N/A, Primera Clave, Segnda Clave, Token, OTP, ETC...)
        /// </summary>
        public string NivelAutenticacion { get; set; }

        /// <summary>
        /// Regla de Negocio que indica el segmento de llamada
        /// </summary>
        public string ReglaNegocio { get; set; }

        /// <summary>
        /// Clave cifrada por hardware de la autenticacion realizada por medio del IVR
        /// </summary>
        public string ClaveHardware { get; set; }

        /// <summary>
        /// Numero del cual llama el cliente
        /// </summary>
        public string Ani { get; set; }

        /// <summary>
        /// Ultimo objeto telefonico (VDN o DID) por el cual pasa la llamada
        /// </summary>
        public string Dnis { get; set; }

        /// <summary>
        /// Opcion de menu que desbordo la llamada al asesor
        /// </summary>
        public string OpcionMenu { get; set; }

        /// <summary>
        /// IP del equipo del agente que recibe la llamada
        /// </summary>
        public string IpMaquina { get; set; }
    }
}