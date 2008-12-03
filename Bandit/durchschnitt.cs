using System;
using System.Collections.Generic;
using System.Text;

namespace Bandit
{
    class durchschnitt
    {
        private long Summe;
        private long anzZahlen;
        public void hinzufuegen(long zahl)
        {
            Summe += zahl;
            anzZahlen++;
        }
        public long getDurchschnitt()
        {
            return (Summe / anzZahlen);
        }

    }
}
