using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RADVupTiles
{
    public class DataTableWrapper
    {
        private DataTable _dt = new DataTable();

        public DataTableWrapper(DataTable dt)
        {
            _dt = dt;
        }

        public DataTable GetTable()
        {
            return _dt;
        }
    }
}