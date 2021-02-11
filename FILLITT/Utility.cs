using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILLITT
{
    class Utility
    {
        public void RunProgram()
        {
            Database db = new Database();
            db.CreateDatabase();
            db.CreateTable();
        }
    }
}
