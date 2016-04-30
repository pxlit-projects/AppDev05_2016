using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
{
    public interface IDesDriverRepository 
    {
        String GetDriverName();
        List<DesDriver> ActiveDrivesPerEvent(int eventId);
        void unSetDES(int userId, int eventId);
        void setDES(int userId, int eventId, int places);
        List<DesDriver> GetAllDrivers();
        bool IsDES(int userId, int eventId);
        bool WasDES(int userId, int eventId);
        int GetFreeSpaces(int userId);
    }
}