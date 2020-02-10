using System.Collections.Generic;

namespace ServerApp.Models
{
    public class Info
    {
        public List<Citizenship> Citizenships { get; set; }

        public List<Disability> Disabilities { get; set; }

        public List<City> Cities { get; set; }

        public List<FamilyPosition> FamilyPositions { get; set; }

        public List<Currency> Currencies { get; set; }
    }
}