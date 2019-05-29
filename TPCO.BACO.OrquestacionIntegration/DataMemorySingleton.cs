using System.Collections.Generic;
using TPCO.BACO.OrquestacionIntegration.Entities;

namespace TPCO.BACO.OrquestacionIntegration
{
    public class DataMemorySingleton
    {
        private static DataMemorySingleton dataMemorySingleton;

        public List<CallData> ListDataCall { get; set; }

        private DataMemorySingleton() { }

        public static DataMemorySingleton DataMemory
        {
            get
            {
                if (dataMemorySingleton == null)
                {
                    dataMemorySingleton = new DataMemorySingleton
                    {
                        ListDataCall = new List<CallData>()
                    };
                }
                return dataMemorySingleton;
            }
        }
    }
}