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
    /// Interaction logic for ResevationInfo44.xaml
    /// </summary>
    public partial class ResevationInfo : Page
    {
        private Reception Reception;
        private Reservation Reservation;
        private ContentControl ContentControl;
        public ResevationInfo(Reservation reservation, Reception reception, ContentControl contentControl)
        {
            //iniatilaizing page and sets properties
            InitializeComponent();
            Reservation = reservation;
            Reception = reception;
            ContentControl = contentControl;

            //sets textbox text to resevation info
            firstName.Text = Reservation.Customer.FirstName;
            lastName.Text = Reservation.Customer.LastName;
            email.Text = Reservation.Customer.Email;
            phoneNumber.Text = Reservation.Customer.PhoneNumber;
            roomNumber.Text = Reservation.Room.Number.ToString();
            price.Text = Reservation.Room.GetTotalPrice(Reservation.GetTimeSpan()).ToString();
            startDate.Text = Reservation.StartDate.ToString();
            endDate.Text = Reservation.EndDate.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //removes the current resevation and changes page to resevations
            Reception.RemoveReservation(this.Reservation.OrderNumber);
            Resevations resevations = new Resevations(ContentControl,Reception);
            ContentControl.Content = resevations.Content;
        }
    }
}
