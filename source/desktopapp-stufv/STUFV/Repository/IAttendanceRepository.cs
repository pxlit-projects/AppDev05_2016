using System.Collections.Generic;

namespace STUFV.Repository
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAllAttendance();
        void UnSignAttend(int userId, int eventId);
        void SignAttend(int userId, int eventId);
        bool IsAttending(int userId, int eventId);
        bool WasAttending(int userId, int eventId);
    }
}