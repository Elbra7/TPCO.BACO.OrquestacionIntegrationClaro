using Newtonsoft.Json;
using System;
using Teleperformance.Helpers.Logger;
using TPCO.BACO.OrquestacionIntegration.Entities;

namespace TPCO.BACO.OrquestacionIntegration.Services
{
    public class MemoryDataService
    {
        private readonly string key = "?E(H+MbQeThVmYq3t6w9z$C&F)J@NcRf";
        public CallData InsertMemoryData(ResponseQuery dataReturn)
        {
            CallData callData;
            try
            {
                var decryptedString = SymmetricCipherService.DecriptString(key, dataReturn.orqData);
                var orchestratorData = JsonConvert.DeserializeObject<OrquestationDataRequest>(decryptedString);
                callData = new CallData
                {
                    //Falta el resto de campos
                    UCID = orchestratorData.idOrigen
                };
                WebApiApplication.dataMemorySingleton.ListDataCall.Add(callData);
                return callData;
            }
            catch (Exception e)
            {
                LoggerManager.Logger.WriteMessage(LogLevel.Error, LogTags.EXCEPTION, $"Exception in InsertMemoryData: {e.Message} ", e);
                return null;
            }
        }
        
        public CallData ReadMemoryData(string UCID)
        {
            CallData callDataMemory = new CallData();
            try
            {
                callDataMemory = WebApiApplication.dataMemorySingleton.ListDataCall.Find(x => x.UCID == UCID);
                return callDataMemory;
            }
            catch (Exception e)
            {
                LoggerManager.Logger.WriteMessage(LogLevel.Error, LogTags.EXCEPTION, $"Exception in ReadMemoryData UCID: {UCID} - Error: {e.Message} ", e);
                return null;
            }


        }

        public bool DeleteMemoryData(string UCID)
        {
            try
            {
                WebApiApplication.dataMemorySingleton.ListDataCall.Remove(new CallData() { UCID = UCID });
                return true;
            }
            catch (Exception e)
            {
                //LoggerManager.Logger.WriteMessage(LogLevel.Error, LogTags.EXCEPTION, $"Error Eliminando los Datos en Momoeria UCID: {UCID} - Error: {e.Message} ", e);
                return false;
            }
        }
    }
}