using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoftVsSystemText
{
    public class Party
    {
        public string Theme { get; set; }
        public DateTime PartyDateTime { get; set; }
        public ICake AbstractCake { get; set; }
        public NestedCake ConcreteCake { get; set; }
    }

    public class ForgivingParty
    {
        public string? Theme { get; set; }
        public DateTime? PartyDateTime { get; set; }
        public ICake? AbstractCake { get; set; }
        public NestedCake? ConcreteCake { get; set; }
    }

    public class SimpleParty
    {
        public DateTime? PartyDateTime { get; set; }
        public ICake? AbstractCake { get; set; }
        public NestedCake? ConcreteCake { get; set; }
    }

    public class SuperSimpleParty
    {
        public DateTime PartyDateTime { get; set; }
        public NestedCake ConcreteCake { get; set; }
    }
}
