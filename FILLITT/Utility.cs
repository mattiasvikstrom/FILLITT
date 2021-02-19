using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FILLITT
{
    public class Utility : Form1
    {
        public void RunProgram()
        {
            Database db = new Database();
            db.RunDatabaseCheck();
            
        }
    }
}
