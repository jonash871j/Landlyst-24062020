using LandLystLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace landlyst
{
    /// <summary>
    /// Interaction logic for BookRoom.xaml
    /// </summary>
    
    
    
    public partial class BookRoom : Page
    {
        private ContentControl ContentControl;
        private Room Room;
        private Reception Reception;
        public BookRoom(ContentControl contentControl, Room room, Reception reception)
        {
            //iniatilaizing page and sets properties
            ContentControl = contentControl;
            InitializeComponent();
            Room = room;
            Reception = reception;
            

        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            //sets the date to tommorow if the chosen one is before today
            if (datePicker.SelectedDate < DateTime.Now)
            {
                datePicker.SelectedDate = DateTime.Today.AddDays(1);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //makes a resevation and changes the page to resevations 
            Customer customer = new Customer(firstname.Text,lastname.Text,adresse.Text,city.Text,postal.Text,country.Text,email.Text,phoneNumber.Text);
            Reservation reservation = new Reservation(customer,Room,DateTime.Now, (DateTime)datePicker.SelectedDate);
            Reception.CreateCustomer(customer);
            Reception.CreateReservation(reservation);
            Resevations resevations = new Resevations(ContentControl,Reception);
            ContentControl.Content = resevations;
        }
    }
}
