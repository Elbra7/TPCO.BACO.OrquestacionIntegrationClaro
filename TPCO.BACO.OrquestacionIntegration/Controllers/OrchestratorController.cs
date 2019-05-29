using System;
using System.Web.Http;
using Teleperformance.Helpers.Logger;
using TPCO.BACO.OrquestacionIntegration.Entities;
using TPCO.BACO.OrquestacionIntegration.Services;

namespace TPCO.BACO.OrquestacionIntegration.Controllers
{
    public class OrchestratorController : ApiController
    {
        private OrchestratorService orquestadorService = new OrchestratorService();
        private MemoryDataService memoryDataService = new MemoryDataService();
        private ResponseQuery responseQuery;
        private CallData callData;

        [HttpPost]
        [Route("api/Orchestrator/InsertData")]
        public IHttpActionResult InsertData([FromBody] CallData request)
        {
            try
            {
                LoggerManager.Logger.WriteMessage(LogLevel.Info, LogTags.TRACE, $"Begin Request Insert Data - UCID{ request.UCID }: ", request);
                var response = orquestadorService.InsertData(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/Orchestrator/GetInfoById/{idLlamada}")]
        public IHttpActionResult GetInfoById([FromUri] string idLlamada)
        {
            try
            {
                LoggerManager.Logger.WriteMessage(LogLevel.Info, LogTags.TRACE, "Ejecución de método GetInfoById(), dato de entrada: ", idLlamada);
                responseQuery = orquestadorService.GetData(idLlamada);
                callData = memoryDataService.InsertMemoryData(responseQuery);
                return Ok(callData);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
