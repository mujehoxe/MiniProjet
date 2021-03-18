using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
<<<<<<< HEAD
<<<<<<< HEAD
    interface ILabManager
=======
    public interface IUser{}
    public interface ILabManager : IUser
>>>>>>> 7c5c408 (providing class)
=======
    public interface IUser{}
    public interface ILabManager : IUser
>>>>>>> 7c5c408 (providing class)
    {
        bool ModifyProfile(Profile profile);
        void OrganizeManifestation(DateTime date);
        void AffiliateResearcher(string researcherid, string teamid);
        void ModifyTeamLead(string teamid, string researcherid);
    }
<<<<<<< HEAD
    interface IResearcher
=======

    public interface IResearcher : IUser
<<<<<<< HEAD
>>>>>>> 7c5c408 (providing class)
=======
>>>>>>> 7c5c408 (providing class)
    {
        bool ModifyProfile(Profile profile);
        bool PublishScientificProduction(ScientificProduction S);
    }
<<<<<<< HEAD
<<<<<<< HEAD
    interface ILead
=======
    public interface ILead : IUser
>>>>>>> 7c5c408 (providing class)
=======
    public interface ILead : IUser
>>>>>>> 7c5c408 (providing class)
    {
         
    }
}
