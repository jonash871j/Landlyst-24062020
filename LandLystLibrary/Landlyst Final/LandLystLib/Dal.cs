using System;
using System.Collections.Generic;
using Npgsql;
using NpgsqlTypes;

namespace LandLystLib
{
    internal class Dal
    {
        private string connectionString;

        public Dal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /*+-+-+-+-Reservation section+-+-+-+-*/

        /// <summary>
        /// Creates a reservation by using the reservation object and stores it in database
        /// </summary>
        public void CreateReservation(Reservation reservation)
        {
            NpgsqlCommand command = new NpgsqlCommand("CALL SP_MakeReservation(" +
                "@ordernumber," +
                "@email, " +
                "@roomnumber, " +
                "@startdate, " +
                "@enddate);"
            );

            command.Parameters.AddWithValue("ordernumber", reservation.OrderNumber);
            command.Parameters.AddWithValue("email", reservation.Customer.Email);
            command.Parameters.AddWithValue("roomnumber", reservation.Room.Number);
            command.Parameters.AddWithValue("startdate", NpgsqlDbType.Date, reservation.StartDate);
            command.Parameters.AddWithValue("enddate", NpgsqlDbType.Date, reservation.EndDate);

            ExecuteNonQuery(command);
        }

        /// <summary>
        /// Removes a reservation by using the order id
        /// </summary>
        public void RemoveReservation(int order)
        {
            NpgsqlCommand command = new NpgsqlCommand("CALL SP_DeleteReservationByOrderNumber(@ordernumber);");
            command.Parameters.AddWithValue("ordernumber", order);
            ExecuteNonQuery(command);
        }

        /// <summary>
        /// Gets a list with all reservations in database 
        /// </summary>
        public List<Reservation> GetReservations()
        {
            // Locals
            List<Reservation> reservations = new List<Reservation>();
            List<string> customerEmails = new List<string>();
            List<int> roomNumbers = new List<int>();

            // Execute function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM FP_GetReservations()", connection);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads all content from reservations table
            while (reader.Read())
            {
                customerEmails.Add(reader.GetString(1));
                roomNumbers.Add(reader.GetInt32(2));

                reservations.Add(new Reservation(
                    null, 
                    null, 
                    reader.GetDateTime(3), 
                    reader.GetDateTime(4), 
                    reader.GetDateTime(5),
                    reader.GetInt32(0)
                ));
            }
            connection.Close();

            // Adds customers and room to reservation
            for (int i = 0; i < reservations.Count; i++)
            {
                reservations[i].Customer = GetCustomer(customerEmails[i]);
                reservations[i].Room = GetRoom(roomNumbers[i]);
            }

            return reservations;
        }

        /*+-+-+-+-Customer section+-+-+-+-*/

        /// <summary>
        /// Used to create a customer using customer object and stores it in database 
        /// </summary>
        public void CreateCustomer(Customer customer)
        {
            NpgsqlCommand command = new NpgsqlCommand("CALL SP_CreateCustomer(" +
                "@customeremail, " +
                "@customerpostal, " +
                "@customerfirstname, " +
                "@customerlastname, " +
                "@customerphonenumber, " +
                "@customeraddress, " +
                "@customercountry);"
            );
            command.Parameters.AddWithValue("customeremail", customer.Email);
            command.Parameters.AddWithValue("customerpostal", customer.Postal);
            command.Parameters.AddWithValue("customerfirstname", customer.FirstName);
            command.Parameters.AddWithValue("customerlastname", customer.LastName);
            command.Parameters.AddWithValue("customerphonenumber", customer.PhoneNumber);
            command.Parameters.AddWithValue("customeraddress", customer.Address);
            command.Parameters.AddWithValue("customercountry", customer.Country);
            
            ExecuteNonQuery(command);
        }

        /// <summary>
        /// Used to get information about the customer with the given email 
        /// </summary>
        public Customer GetCustomer(string email)
        {
            Customer customer = null;

            // Creates command
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM FP_GetCustomer(@email)", connection);
            command.Parameters.AddWithValue("@email", email);

            // Opens connections
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads table
            while (reader.Read())
                customer = new Customer(reader.GetString(1), reader.GetString(2), reader.GetString(4), reader.GetString(6), reader.GetString(5), reader.GetString(7), reader.GetString(0), reader.GetString(3));
            connection.Close();

            return customer;
        }

        /*+-+-+-+-Room section+-+-+-+-*/

        /// <summary>
        /// Used to get room from its number
        /// </summary>
        public Room GetRoom(int roomNumber)
        {
            // Locals 
            List<RoomAddition> roomAdditions = GetRoomAdditions(roomNumber);
            double roomPrice = 0.0;
            bool doesExist = false;

            // Creates command
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("Select * FROM FP_GetRoom(@roomnumber); ", connection);
            command.Parameters.AddWithValue("@roomnumber", roomNumber);

            // Opens connections
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads table
            while (reader.Read())
            {
                roomPrice = reader.GetDouble(3);
                doesExist = true;
            }
            connection.Close();

            // When no room exist throw exception
            if (!doesExist)
                throw new Exception("Room " + roomNumber.ToString() + " does exist on the hotel.");

            return new Room(roomAdditions, roomNumber, roomPrice);
        }

        /// <summary>
        /// Used to get all room numbers
        /// </summary>
        public List<int> GetRoomNumbers()
        {
            // Locals
            List<int> roomNumbers = new List<int>();

            // Creates function
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM FP_GetRoomNumbers()", connection);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads table
            while (reader.Read())
                roomNumbers.Add(reader.GetInt32(0));
            connection.Close();

            return roomNumbers;
        }

        /// <summary>
        /// Used to get a list with the additions of the given room
        /// </summary>
        public List<RoomAddition> GetRoomAdditions(int roomNumber)
        {
            // Locals
            List<RoomAddition> roomAdditions = new List<RoomAddition>();

            // Creates commands
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("Select * FROM FP_GetRoomAdditions(@roomnumber); ", connection);
            command.Parameters.AddWithValue("@roomnumber", roomNumber);

            // Opens connection
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads table
            while (reader.Read())
                roomAdditions.Add(new RoomAddition(reader.GetString(0), reader.GetDouble(1)));
            connection.Close();

            return roomAdditions;
        }

        /// <summary>
        /// Used to get all available rooms in a specified timeperiod and a given additions filter
        /// </summary>
        public List<Room> GetAvailableRooms(List<string> additionsFilter, DateTime startDate, DateTime endDate)
        {
            // Locals
            List<int> roomNumbers = new List<int>();
            List<Room> rooms = new List<Room>();
            int roomIndex = 0;

            // Creates commands
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand("Select * FROM FP_FindAvailableRooms(@startDate, @endDate); ", connection);
            command.Parameters.AddWithValue("@startDate", NpgsqlDbType.Date, startDate);
            command.Parameters.AddWithValue("@endDate", NpgsqlDbType.Date, endDate);

            // Creates function
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
                
            // Reads all available room numbers in the given timespan 
            while (reader.Read())
                roomNumbers.Add(reader.GetInt32(0));
            connection.Close();

            // Loops through all room numbers
            for (int i = 0; i < roomNumbers.Count; i++)
            {
                // Adds room to list
                rooms.Add(GetRoom(roomNumbers[i]));

                // Checks the filter if theres any addition
                if (additionsFilter.Count > 0)
                {
                    if (!rooms[roomIndex].CheckAdditionsFilter(additionsFilter))
                        rooms.RemoveAt(roomIndex);
                    else
                        roomIndex++;
                }
            }
            return rooms;
        }

        /// <summary>
        /// Used to check if a room is available in a given timespan
        /// </summary>
        public bool CheckAvailableRoom(int roomNumber, DateTime startDate, DateTime endDate)
        {
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM FP_CheckAvailableRoom(" +
                "@roomnumber," +
                "@startdate, " +
                "@enddate);"
            );
            command.Parameters.AddWithValue("roomnumber", roomNumber);
            command.Parameters.AddWithValue("startdate", NpgsqlDbType.Date, startDate);
            command.Parameters.AddWithValue("enddate", NpgsqlDbType.Date, endDate);

            return CheckRead(command);
        }

        /*+-+-+-+-Ordernumber+-+-+-+-*/

        /// <summary>
        /// Used to create a unique order number
        /// </summary>
        public int CreateOrderNumber()
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                // Picks random number
                int randomOrder = random.Next(0, 0x6FFFFFFF);

                // Execute function
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM FP_CheckOrderNumber(@number);");
                command.Parameters.AddWithValue("number", randomOrder);

                // Reads from database and checks if number exists
                bool doesExist = CheckRead(command);
                if (!doesExist)
                    return randomOrder;
            }
            throw new Exception("Low on unique order numbers!");
        }

        /// <summary>
        /// Used to get all newly created orders, and then remove the content
        /// </summary>
        public Queue<int> GetNewlyCreatedOrders()
        {
            // Locals
            Queue<int> newOrderNumbers = new Queue<int>();

            // Creates commands
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand commandGet = new NpgsqlCommand("Select * FROM FP_Getinvoicequeue(); ", connection);
            NpgsqlCommand commandClear = new NpgsqlCommand("CALL SP_Deleteinvoicequeue(); ", connection);

            // Creates function
            connection.Open();
            NpgsqlDataReader reader = commandGet.ExecuteReader();

            // Reads all newly created ordernumbers and enqueue them to a queue
            while (reader.Read())
                newOrderNumbers.Enqueue(reader.GetInt32(0));

            // Delete all newly created ordernumbers from table
            ExecuteNonQuery(commandClear);
            connection.Close();

            return newOrderNumbers;
        }

        /// <summary>
        /// Used to add newly created order number back to invoicequeue when invoice isn't send to a customer
        /// </summary>
        /// <param name="orderNumber"></param>
        public void AddNewlyCreatedOrder(int orderNumber)
        {
            NpgsqlCommand command = new NpgsqlCommand("CALL SP_AddToInvoicequeue(@orderNumber); ");
            command.Parameters.AddWithValue("orderNumber", orderNumber);
            ExecuteNonQuery(command);
        }

        /*+-+-+-+-Email section+-+-+-+-*/

        /// <summary>
        /// Used to check if customer email exists
        /// </summary>
        public bool CheckEmailExists(string email)
        {
            // Execute function
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM FP_CheckEmail(@email);");
            command.Parameters.AddWithValue("email", email);
            
            return CheckRead(command);
        }

        /*+-+-+-+-Simplify functions+-+-+-+-*/

        /// <summary>
        /// Used to open connection and executes non query command
        /// </summary>
        private void ExecuteNonQuery(NpgsqlCommand command)
        {
            // Creates connection
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            command.Connection = connection;

            // Opens connections and writes to table
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Used to check if something can be read, opens connection, trys to read, closes connection
        /// </summary>
        private bool CheckRead(NpgsqlCommand command)
        {
            // Creats connection
            bool doesExist = false;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            command.Connection = connection;

            // Opens opens connections
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            // Reads table
            while (reader.Read())
                doesExist = true;
            connection.Close();

            return doesExist;
        }
    }
}