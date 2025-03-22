using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModel;
using Reservoom.ViewModels;
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
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;

        public App()
        {

            _hotel = new Hotel("famous Hotel");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService( _navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationViewModel));
        }
    }
}  
