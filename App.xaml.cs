using Reservoom.Exceptions;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("My Hotel");

            try
            {
                hotel.MakeReservation(new Reservation(
                    new RoomId(1, 101),
                    "Alice",
                    new DateTime(2021, 1, 1),
                    new DateTime(2021, 1, 3)));


                hotel.MakeReservation(new Reservation(
                    new RoomId(1, 101),
                    "Alice",
                    new DateTime(2021, 1, 3),
                    new DateTime(2021, 1, 5)));

            }
            catch (ReservationConflictException ex)
            {

            }

            IEnumerable<Reservation> reservations = hotel.GetAllReservations();

            base.OnStartup(e);
        }
    }
}
