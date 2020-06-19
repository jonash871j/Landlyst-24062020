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
using LandLystLib;

namespace landlyst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        //creates the reception with database string to connect to database
        private Reception Reception = new Reception("Server=127.0.0.1; Port=5432; User Id=postgres; Password=123; Database=Landlyst;");

        public MainWindow()
        {
            //iniatilaizing page and sets properties and sets start page to rooms
            InitializeComponent();
            Rooms rooms = new Rooms(contentControl, Reception);
            contentControl.Content = rooms;
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //changes page to resevations
            Resevations resevations = new Resevations(contentControl, Reception);
            contentControl.Content = resevations;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //changes page to rooms
            Rooms rooms = new Rooms(contentControl, Reception);
            contentControl.Content = rooms;
        }
    }
}
