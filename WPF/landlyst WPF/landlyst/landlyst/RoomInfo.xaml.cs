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
    
    public partial class RoomInfo : Page
    {
        private ContentControl contentControl;
        private Room room;
        private Reception Reception = new Reception("Server=127.0.0.1; Port=5432; User Id=postgres; Password=123; Database=landlyst;");
        public RoomInfo(ContentControl contentControl, Room room)
        {
            //iniatilaizing page and sets properties
            InitializeComponent();
            this.contentControl = contentControl;
            this.room = room;
            //sets text in textbox from room
            roomnumber.Text = room.Number.ToString();
            price.Text = room.TotalPrice.ToString();
           
            additions.Text = room.GetAdditionsDescription();

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //creating new room and sets it as the content on screen
            BookRoom bookRoom = new BookRoom(contentControl, room, Reception);
            contentControl.Content = bookRoom.Content;
        }
    }
}
