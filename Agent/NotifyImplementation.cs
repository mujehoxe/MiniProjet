using Shared;
using System;

namespace Agent
{
    public class NotifyImplementation : MarshalByRefObject, Shared.INotify
    {
        public void InformResearcherWithSameField(ScientificProduction sp)
        {
            Console.WriteLine("{1} \t {2} \t {3}", sp.Content, sp.Title, sp.Type);
        }
    }
}
