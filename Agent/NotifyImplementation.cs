using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    class NotifyImplementation : MarshalByRefObject, Shared.INotify
    {
        public void InformResearcherWithSameField(ScientificProduction sp)
        {
            Console.WriteLine("{1} \t {2} \t {3}", sp.Content, sp.Title, sp.Type);
        }
    }
}
