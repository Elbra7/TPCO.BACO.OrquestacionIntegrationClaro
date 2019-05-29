using System.Collections.Generic;

namespace TPCO.BACO.OrquestacionIntegration.Entities
{
    public class ResponseQuery
    {
        public string orqData { get; set; }
        public string orqEstado { get; set; }
        public OrchestratorPK orquestadorPK { get; set; }

        //public ResponseQuery()
        //{
        //    orquestadorPK = new List<OrchestratorPK>();
        //}
    }
}