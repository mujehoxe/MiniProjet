using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
<<<<<<< HEAD
    public interface IUser{
        Profile RetriveProfile();
=======
    public interface IUser
    {
        Profile RetrieveProfile();
>>>>>>> 8c7369ae86bdf91aa4dc7847032720ac7e5d7669
    }
    public interface ILabManager : IUser
    {
        bool ModifyProfile(Profile profile);
        void OrganizeManifestation(DateTime date);
        void AffiliateResearcher(string researcherid, string teamid);
        void ModifyTeamLead(string teamid, string researcherid);
    }

    
    public interface IResearcher : IUser
    {
        bool ModifyProfile(Profile profile);
        string PublishScientificProduction(ScientificProduction S, int researcherId);
    }


    public interface ILead : IUser
    {
         
    }
}
