using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TB_NET_2023_APIMusique.Tools.Utils
{
    public static class AddSqlParameterUtils
    {
        public static void addParamWithValue(this DbCommand cmd,string paramName,Object? paramValue)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue ?? DBNull.Value;
            cmd.Parameters.Add(param);
        }
    }
}
