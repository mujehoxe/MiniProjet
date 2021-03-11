using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    interface ILabManager
    {
        bool ModifyProfile();
        void OrganizeManifestation(DateTime date);
        void AffiliateResearcher(string researcherid, string teamid);
        void ModifyTeamLead(string teamid, string researcherid);
    }
    interface IResearcher
    {
        bool ModifyProfile();
        bool PublishScientificProduction(SientificProduction S);
    }
    interface ILead
    {
        
    }
}
