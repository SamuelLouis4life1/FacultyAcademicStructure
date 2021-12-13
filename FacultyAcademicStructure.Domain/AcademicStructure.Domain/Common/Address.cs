using System.Collections.Generic;


namespace AcademicStructure.Domain.Common
{
    public class Address : EntityBase
    {
        public string CEP { get; set; }
        public string AddicionalAddress { get; set; }
        public string HouseAddress { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
