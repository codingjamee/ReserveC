using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    class Reservation
    {
        public RoomId RoomId { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime - StartTime;
        public Reservation(RoomId roomId, string username, DateTime startTime, DateTime endTime)
        {
            RoomId = roomId;
            StartTime = startTime;
            EndTime = endTime;
            Username = username;
        }

        internal bool Conflicts(Reservation reservation)
        {
            if(reservation.RoomId != RoomId)
            {
                return false;
            }
            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
