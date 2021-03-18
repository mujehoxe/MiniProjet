using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
    public interface ILabManager
>>>>>>> nmjkh
=======
    public interface IUser{}
    public interface ILabManager : IUser
>>>>>>> providing class
    {
        bool ModifyProfile(Profile profile);
        void OrganizeManifestation(DateTime date);
        void AffiliateResearcher(string researcherid, string teamid);
        void ModifyTeamLead(string teamid, string researcherid);
    }
<<<<<<< HEAD
<<<<<<< HEAD
    interface IResearcher
=======

    public interface IResearcher : IUser
<<<<<<< HEAD
>>>>>>> 7c5c408 (providing class)
=======
>>>>>>> 7c5c408 (providing class)
=======

<<<<<<< HEAD
    public interface IResearcher
>>>>>>> nmjkh
=======
    public interface IResearcher : IUser
>>>>>>> providing class
    {
        bool ModifyProfile(Profile profile);
        string PublishScientificProduction(ScientificProduction S, int researcherId);
    }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    interface ILead
=======
    public interface ILead : IUser
>>>>>>> 7c5c408 (providing class)
=======
    public interface ILead : IUser
>>>>>>> 7c5c408 (providing class)
=======
    public interface ILead
>>>>>>> nmjkh
=======
    public interface ILead : IUser
>>>>>>> providing class
    {
         
    }
}
