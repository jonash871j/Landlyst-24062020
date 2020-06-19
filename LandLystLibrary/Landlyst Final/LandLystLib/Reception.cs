using System;
using System.Collections.Generic;

namespace LandLystLib
{
    public class Reception
    {
        private Email email;
        private Invoice invoice;
        private Dal dal;

        public Reception(string connectionString, string emailAddress = "landlystnoreply@gmail.com", string emailPassword = "LandLyst123")
        {
            email = new Email(emailAddress, emailPassword);
            invoice = new Invoice(email);
            dal = new Dal(connectionString);
        }

        /*+-+-+-+-Reservation section+-+-+-+-*/

        /// <summary>
        /// Creates a reservation by using the reservation object and stores it in database
        /// </summary>
        public void CreateReservation(Reservation reservation)
        {
            reservation.OrderNumber = dal.CreateOrderNumber();
            dal.CreateReservation(reservation);
        }

        /// <summary>
        /// Removes a reservation by using the order id
        /// </summary>
        public void RemoveReservation(int orderNumber)
        {
            dal.RemoveReservation(orderNumber);
        }

        /// <summary>
        /// Gets a list with all reservations in database 
        /// </summary>
        public List<Reservation> GetReservations()
        {
            return dal.GetReservations();
        }

        /*+-+-+-+-Customer section+-+-+-+-*/

        /// <summary>
        /// Creates a customer using customer object and stores it in database 
        /// </summary>
        public void CreateCustomer(Customer customer)
        {
            dal.CreateCustomer(customer);
        }

        /// <summary>
        /// Gets information about the customer with the given email 
        /// </summary>
        public Customer GetCustomer(string email)
        {
            return dal.GetCustomer(email);
        }

        /*+-+-+-+-Room section+-+-+-+-*/

        /// <summary>
        /// Used to get room from its number
        /// </summary>
        public Room GetRoom(int roomNumber)
        {
            return dal.GetRoom(roomNumber);
        }

        /// <summary>
        /// Used to get all rooms no matter if they are available or not
        /// </summary>
        public List<Room> GetRooms()
        {
            List<int> roomNumbers = dal.GetRoomNumbers();
            List<Room> rooms = new List<Room>(roomNumbers.Count);

            for (int i = 0; i < roomNumbers.Count; i++)
                rooms.Add(dal.GetRoom(roomNumbers[i]));

            return rooms;
        }

        /// <summary>
        /// Used to get all room numbers
        /// </summary>
        public List<int> GetRoomNumbers()
        {
            return dal.GetRoomNumbers();
        }

        /// <summary>
        /// Gets a list with the additions of the given room
        /// </summary>
        public List<RoomAddition> GetRoomAdditions(int roomNumber)
        {
            return dal.GetRoomAdditions(roomNumber);
        }

        /// <summary>
        /// Used to get all available rooms in a specified timeperiod and a given additions filter
        /// </summary>
        public List<Room> GetAvailableRooms(List<string> additionsFilter, DateTime startDate, DateTime endDate)
        {
            return dal.GetAvailableRooms(additionsFilter, startDate, endDate);
        }

        /// <summary>
        /// Used to check if a room is available in a given timespan
        /// </summary>
        public bool CheckAvailableRoom(int roomNumber, DateTime startDate, DateTime endDate)
        {
            return dal.CheckAvailableRoom(roomNumber, startDate, endDate);
        }

        /*+-+-+-+-Newly created order numbers+-+-+-+-*/

        /// <summary>
        /// Used to get all newly created orders, and then remove the content
        /// </summary>
        public Queue<int> GetNewlyCreatedOrders()
        {
            return dal.GetNewlyCreatedOrders();
        }

        /// <summary>
        /// Used to add newly created order number back to invoicequeue when invoice isn't send to a customer
        /// </summary>
        public void AddNewlyCreatedOrder(int orderNumber)
        {
            dal.AddNewlyCreatedOrder(orderNumber);
        }

        /*+-+-+-+-Email section+-+-+-+-*/

        /// <summary>
        /// Used to send invoice to a customer that has a reservation
        /// </summary>
        public void SendInvoice(Reservation reservation, string templatePath, string templateFilename)
        {
            invoice.Send(reservation, templatePath, templateFilename);
        }

        /// <summary>
        /// Used to send order to a customer that has a reservation
        /// </summary>
        /// <param name="reservation"></param>
        public void SendOrder(Reservation reservation)
        {
            Customer customer = reservation.Customer;
            Room room = reservation.Room;

            email.SendEmail(
                reservation.Customer.Email,
                "Hotel Landlyst - Ordrebekræftelse",

                "Hej " + customer.FirstName + 
                "\n\nDit ordernummer er: " + reservation.OrderNumber.ToString() +
                ".\nDu har booket rum nr. " + room.Number.ToString() + 
                " i denne periode " + reservation.StartDate.ToShortDateString() + " - " + reservation.EndDate.ToShortDateString() +
                ".\n\n\nMed Venlig Hilsen\n\nHotel Landlyst"
            );
        }

        /// <summary>
        /// Used to send email to customer
        /// </summary>
        public void SendEmail(string customerEmail, string subject, string message)
        {
            email.SendEmail(customerEmail, subject, message);
        }

        /// <summary>
        /// Used to check if customer email exists
        /// </summary>
        public bool CheckEmailExists(string customerEmail)
        {
            return dal.CheckEmailExists(customerEmail);
        }

        /*+-+-+-+-Word section+-+-+-+-*/

        /// <summary>
        /// Used to open office word
        /// </summary>
        public void OpenWord()
        {
            invoice.OpenWord();
        }

        /// <summary>
        /// Used to close office word
        /// </summary>
        public void CloseWord()
        {
            invoice.CloseWord();
        }
    }
}