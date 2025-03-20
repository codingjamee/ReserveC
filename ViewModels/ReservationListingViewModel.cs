using Reservoom.Models;
using Reservoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand
        {
            get;
        }


        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            _reservations.Add(new ReservationViewModel(new Reservation(new RoomId(1, 2), "Alice", DateTime.Now, DateTime.Now.AddHours(1))));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomId(3, 2), "Blice23", DateTime.Now, DateTime.Now.AddHours(1))));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomId(2, 4), "Clice3", DateTime.Now, DateTime.Now.AddHours(1))));
        }
    }
}
