using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; set; }
        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }   
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }
        /// <summary>
        /// Make a reservation
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        /// <exception cref="ReservationConflictException"></exception>
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}
