using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;
namespace webapp_stufv.Repository
{
    public interface IOrganisationRepository
    {
        List<Organisation> GetAllOrganisations();
        int HasOrganisation(int userId);
        void NewOrganisation(int userId, String name, String disc);
        string GetOrganisationName(int userId);
    }
}