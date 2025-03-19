using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Exceptions
{
    class ReservationConflictException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }


        public ReservationConflictException(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string message) : base(message)
        {
        }

        public ReservationConflictException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is ReservationConflictException exception &&
                   EqualityComparer<Reservation>.Default.Equals(ExistingReservation, exception.ExistingReservation) &&
                   EqualityComparer<Reservation>.Default.Equals(IncomingReservation, exception.IncomingReservation);
        }
    }
}
