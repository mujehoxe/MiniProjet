using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    interface ILabManager
    {
        bool ModifyProfile(Profile profile);
        void OrganizeManifestation(DateTime date);
        void AffiliateResearcher(string researcherid, string teamid);
        void ModifyTeamLead(string teamid, string researcherid);
    }
    interface IResearcher
    {
        bool ModifyProfile(Profile profile);
        bool PublishScientificProduction(ScientificProduction S);
    }
    interface ILead
    {
         
    }
}
