using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using LandLystLib;

namespace InvoiceSender
{
    class Program
    {
        static Reception reception;
        static string connection = "null";
        static string path = "null";
        static string templateFilename = "null";
        static int updateTime = 10000;

        /*Labels*/
        static void LabelTime()
        {
            Console.Write("<" + DateTime.Now.ToLongTimeString() + "> ");
        }
        static void LabelFatalError()
        {
            LabelTime();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[FATAL FEJL] ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void LabelError()
        {
            LabelTime();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("[FEJL] ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void LabelSuccess()
        {
            LabelTime();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[SUCCES] ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void LabelInfo()
        {
            LabelTime();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[INFO] ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void LabelWarning()
        {
            LabelTime();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[ADVARSEL] ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Used to send invoices
        /// </summary>
        static bool SendInvoices()
        {
            Queue<int> queue = reception.GetNewlyCreatedOrders();
            if (queue.Count == 0)
                return false;

            // Opens word
            if (!OpenWord())
                return false;

            LabelInfo();
            Console.WriteLine("Læser fra invoice-queue.dat...");

            Queue<int> failed = new Queue<int>();
            List<Reservation> reservations = reception.GetReservations();

            LabelInfo();
            if (queue.Count == 1)
                Console.WriteLine(queue.Count + " kunde er ved at få sendt en fakture...");
            else
                Console.WriteLine(queue.Count + " kunder er ved at få sendt en fakture...");

            int index = 0;
            int invalid = 0;

            // Incement all ordernumbers
            foreach (int orderNumber in queue)
            {
                LabelInfo();
                Console.WriteLine("Mails sendt: " + index + " / " + (queue.Count-invalid));

                Reservation reservation = null;

                // Trys to find ordernumber in list
                for (int i = 0; i < reservations.Count; i++)
                    if (reservations[i].OrderNumber == orderNumber)
                        reservation = reservations[i];

                // If there wasn't found any ordernumber that match up give a warning and continue
                if (reservation == null)
                {
                    invalid++;
                    LabelWarning();
                    Console.WriteLine("Reservationen " + orderNumber + " findes ikke i databasen.");
                    continue;
                }

                // If there was found any ordernumber that match up send invoice to customer
                try
                {
                    reception.SendInvoice(reservation, path, templateFilename);
                    index++;

                    LabelSuccess();
                    Console.WriteLine(reservation.Customer.FirstName + " " + reservation.Customer.LastName + " har modtaget fakturaen via: "+ reservation.Customer.Email);
                }
                // If something went wrong give a error
                catch(Exception exception)
                {
                    failed.Enqueue(reservation.OrderNumber);

                    LabelError();
                    Console.WriteLine("En kunde fik ikke sin fakture! - " + orderNumber + " - " + exception.Message);
                }
            }

            // Puts back failed ordernumbers to file
            if (index != queue.Count-invalid)
            {
                LabelWarning();
                Console.WriteLine("Skriver de fejlede mail adresser tilbage til køen...");

                foreach (int orderNumber in failed)
                    reception.AddNewlyCreatedOrder(orderNumber);

                LabelWarning();
            }
            else
                LabelSuccess();

            Console.WriteLine("Mails sendt: " + index + " / " + (queue.Count-invalid));

            // Close word
            reception.CloseWord();

            return true;
        }
        /// <summary>
        /// Used to open word
        /// </summary>
        static bool OpenWord()
        {
            try
            {
                LabelInfo();
                Console.WriteLine("Åbner word...");

                reception.OpenWord();

                LabelSuccess();
                Console.WriteLine("Word er åbenet");
                Thread.Sleep(500);
            }
            catch (Exception exception)
            {
                LabelError();
                Console.WriteLine("Kunne ikke åbne word: " + exception.Message);
                return false;
            }
            return true;

        }
        /// <summary>
        /// Used to read from config
        /// </summary>
        static bool ReadFromConfig()
        {
            try
            {
                // Opens config and read data
                StreamReader streamReader = new StreamReader("./config.ini");
                streamReader.ReadLine();
                connection = streamReader.ReadLine();
                streamReader.ReadLine();
                path = streamReader.ReadLine();
                streamReader.ReadLine();
                templateFilename = streamReader.ReadLine();
                streamReader.ReadLine();
                try
                {
                    updateTime = int.Parse(streamReader.ReadLine());
                }
                catch (Exception exception)
                {
                    streamReader.Close();
                    throw exception;
                }
                streamReader.Close();
            }
            catch
            {
                // If something went wrong create new config file
                StreamWriter streamReader = new StreamWriter("./config.ini");
                streamReader.WriteLine("- ConnectionString");
                streamReader.WriteLine("Server=127.0.0.1; Port=5432; User Id=postgres; Password=; Database=;");
                streamReader.WriteLine("- DocumentsPath");
                streamReader.WriteLine(@"C:\");
                streamReader.WriteLine("- TemplateDocument");
                streamReader.WriteLine(@"template.docx");
                streamReader.WriteLine("- UpdateTime");
                streamReader.WriteLine(updateTime.ToString());
                streamReader.Close();

                LabelFatalError();
                Console.WriteLine("config.ini er ikke blevet konfigureret korrekt!");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Used to connection database
        /// </summary>
        static bool ConnectionToDatabase()
        {
            try
            {
                reception = new Reception(connection);
                reception.GetRoomNumbers();
            }
            catch (Exception exception)
            {
                LabelFatalError();
                Console.WriteLine("Kunne ikke forbinde til databasen! - " + exception.Message);
                Console.ReadKey();
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| Faktura Afsender\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Reads data from config file
            if (!ReadFromConfig())
                return;

            // Connects to database
            if (!ConnectionToDatabase())
                return;


            LabelSuccess();
            Console.WriteLine("Forbundet til databasen");
      
            while (true)
            {
                LabelInfo();
                Console.WriteLine("Tjekker for nye kunder som mangler en fakture...");
                  
                if (!SendInvoices())
                {
                    LabelInfo();
                    Console.WriteLine("Der er ikke blevet sendt nogle nye fakturer...");
                }

                // Sleep time before checking for newly created orders
                Thread.Sleep(updateTime);
            }
        }
    }
}