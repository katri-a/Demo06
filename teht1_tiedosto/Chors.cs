using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teht1_tiedosto
{
    [Serializable]
    class Chors
    {
        public string Chor { get; set; }

        public override string ToString()
        {
            return Chor;
        }
    }
}
