using System.Collections.Generic;

namespace STUFV.Repository
{
    public interface IDesDriverRepository 
    {
        string GetDriverName(int UserId);
        List<DesDriver> ActiveDriversPerEvent(int eventId);
        void unSetDES(int userId, int eventId);
        void SetDES(int userId, int eventId, int places);
        List<DesDriver> GetAllDrivers();
        bool IsDES(int userId, int eventId);
        bool WasDES(int userId, int eventId);
        int GetFreeSpaces(int userId, int NrOfPlaces);
    }
}