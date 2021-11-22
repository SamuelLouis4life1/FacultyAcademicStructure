using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Domain.Common
{
    public abstract class Address
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string AddicionalAddress { get; set; }
        public string HouseAddress { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Number { get; set; }

    }
}
