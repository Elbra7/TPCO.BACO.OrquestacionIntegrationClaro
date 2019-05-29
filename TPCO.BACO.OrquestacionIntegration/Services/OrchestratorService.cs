using System;
using System.Configuration;
using Teleperformance.Helpers.Logger;
using TPCO.BACO.OrquestacionIntegration.Entities;

namespace TPCO.BACO.OrquestacionIntegration.Services
{
    public class OrchestratorService
    {
        public ResponseInsert InsertData(CallData data)
        {
            ResponseInsert responseInsert = new ResponseInsert();
            try
            {
                WebApiHelper clientHttp = new WebApiHelper(ConfigurationManager.AppSettings["OrquestadorBaseAddress"]);
                var DataRequest = new OrquestationDataRequest
                {
                    idOrigen = data.UCID
                };

                DataRequest.orchestratorData = new orquestadorData
                {
                    idInteraccionOrigen = data.UCID,
                    token = data.Token,
                    TipoODA = data.TipoDocumento,
                    documentoCliente = Convert.ToInt32(data.Documento),
                    nivelAutenticacion = data.NivelAutenticacion,
                    reglaNegocio = data.ReglaNegocio,
                    claveHardware = data.ClaveHardware,
                    ani = data.Ani,
                    dnis = data.Dnis,
                    opcionMenu = data.OpcionMenu,
                    operadorOrigen = "T",
                    operadorDestino = "C",
                    iPMaquina = data.IpMaquina
                };

                clientHttp.InvokePost("save", DataRequest, out responseInsert);
                return responseInsert;
            }
            catch (Exception e)
            {
                LoggerManager.Logger.WriteMessage(LogLevel.Error, LogTags.EXCEPTION, $"Exception in InsertData: { e.Message } ", e);
                throw;
            }
        }

        internal ResponseQuery GetData(string idLlamada)
        {
            try
            {
                ResponseQuery responseQuery;
                WebApiHelper clientHttp = new WebApiHelper(ConfigurationManager.AppSettings["OrquestadorBaseAddress"]);
                responseQuery = clientHttp.InvokeGet<ResponseQuery>($"consulta/{idLlamada}");
                LoggerManager.Logger.WriteMessage(LogLevel.Error, LogTags.EXCEPTION, $"ResponseGetData: { responseQuery.orqEstado } ", responseQuery);
                return responseQuery;
            }
            catch (Exception e)
            {
                LoggerManager.Logger.WriteMessage(LogLevel.Error, LogTags.EXCEPTION, $"Exception in GetData: { e.Message } ", e);
                throw;
            }
        }
    }
}