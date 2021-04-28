using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace Architecture.DDD.Infra
{
    public class Location: ValueObject
    {
        public string Premises { get; set; }
        public string Floor { get; set; }

        public Location(string premises, string floor)
        {
            Premises = premises;
            Floor = floor;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Premises;
            yield return Floor;
        }
    }
}
