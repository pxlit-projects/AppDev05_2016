using System;
using System.Collections.Generic;
namespace STUFV.Repository
{
    public interface IOrganisationRepository
    {
        List<Organisation> GetAllOrganisations();
        int HasOrganisation(int userId);
        void NewOrganisation(int userId, String name, String disc);
    }
}