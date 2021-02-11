using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FILLITT
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string DateOfDeath { get; set; }
        public int Mother { get; set; }
        public int Father { get; set; }
        //public string myVar;

        public string DisplayIt
        {
            get { return $"{FirstName}"; }
        }
    }
}
