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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : UserControl
    {
        //sets private attribuets
        private List<Room> rooms = new List<Room>();
        private Reception Reception;
        private ContentControl ContentControl;
        public Rooms(ContentControl contentControl, Reception reception)
        {
            
            InitializeComponent();
            ContentControl = contentControl;
            Reception = reception;
           //fills room list with all rooms in the hotel
            rooms = reception.GetRooms();

            //adds the rooms as listview items in listview
            foreach (Room item in rooms)
            {
                ListViewItem i = new ListViewItem();
                
                i.Content = item;
                listView.Items.Add(i);
            }


        }
  

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            //changes page to roominfo when listviewitem is clicked, takes room as argument when making new roominfo
            ListViewItem li = listView.SelectedItem as ListViewItem;
            Room r = li.Content as Room;
            RoomInfo roomInfo = new RoomInfo(ContentControl, r);
            ContentControl.Content = roomInfo.Content;

           
        }
    }
}
