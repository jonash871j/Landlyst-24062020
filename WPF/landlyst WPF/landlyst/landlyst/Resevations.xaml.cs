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
    /// Interaction logic for Resevations.xaml
    /// </summary>
    
    
    public partial class Resevations : UserControl
    {
        private List<Reservation> Reservations = new List<Reservation>();
        ContentControl contentControl;
        private Reception Reception;
        public Resevations(ContentControl contentControl, Reception reception)
        {
            InitializeComponent();
            this.contentControl = contentControl;
            Reception = reception;
           // Reception reception = new Reception("Server=127.0.0.1; Port=5432; User Id=postgres; Password=123; Database=landlyst;");
            Reservations = Reception.GetReservations();
            
            foreach (Reservation item in Reservations)
            {
                ListViewItem i = new ListViewItem();
                i.Content = item;
                listView.Items.Add(i);
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem li = listView.SelectedItem as ListViewItem;
            Reservation r = li.Content as Reservation;
            ResevationInfo resevationInfo = new ResevationInfo(r,Reception,contentControl);
            contentControl.Content = resevationInfo.Content;
        }
    }
}
