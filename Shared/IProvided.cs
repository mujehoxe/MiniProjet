﻿using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface ILabManager
    {
        bool ModifyProfile(Profile profile);
        void OrganizeManifestation(DateTime date);
        void AffiliateResearcher(string researcherid, string teamid);
        void ModifyTeamLead(string teamid, string researcherid);
    }

    public interface IResearcher
    {
        bool ModifyProfile(Profile profile);
        string PublishScientificProduction(ScientificProduction S, int researcherId);
    }
    public interface ILead
    {
         
    }
}
