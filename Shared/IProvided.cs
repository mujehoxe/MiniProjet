using System;

namespace Shared
{


    public interface IUser
    {
        Profile RetrieveProfile();
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
