using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Modelo
{
    public static class DataSetHelper
    {
        public static bool HasRecords(DataSet ds)
        {
            return
                ds != null
                && ds.Tables.Count > 0
                && ds.Tables[0].Rows.Count > 0;
        }
    }
}