using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapp_stufv.Models;

namespace webapp_stufv.Repository
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