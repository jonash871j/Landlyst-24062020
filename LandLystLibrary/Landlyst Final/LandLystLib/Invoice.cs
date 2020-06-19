using System.IO;
using Microsoft.Office.Interop.Word;

namespace LandLystLib
{
    internal class Invoice
    {
        private Application applicationWord;
        private Document document;
        private Email email;

        public Invoice(Email email)
        {
            this.email = email;
        }

        /// <summary>
        /// Sends invoice to customer from reservation 
        /// </summary>
        public void Send(Reservation reservation, string templatePath, string templateFilename)
        {    
            // Overide template document
            if (File.Exists(templatePath + "Temp.docx"))
                File.Delete(templatePath + "Temp.docx");
            File.Copy(templatePath + templateFilename, templatePath + "Temp.docx");

            // Delete invoice pdf
            if (File.Exists(templatePath + "Faktura.pdf"))
                File.Delete(templatePath + "Faktura.pdf");

            // Opens invoice template in word
            document = applicationWord.Documents.Open(templatePath + "Temp.docx");

            // Creates a invoice document for customer
            CreateInvoice(reservation);

            // Convents .docx to .pdf
            document.Save();
            document.ExportAsFixedFormat(templatePath + "Faktura.pdf", WdExportFormat.wdExportFormatPDF, false);
            document.Close();

            // Sends email to customer
            email.SendEmailAttachement(
                reservation.Customer.Email,
                "Landlyst Fakture",
                "Hej " + reservation.Customer.FirstName + "\n\nHer er din fakture.\n\n\nMed Venlig Hilsen\n\nHotel Landlyst",
                templatePath + "Faktura.pdf");
        }

        /// <summary>
        /// Used to opens office word
        /// </summary>
        public void OpenWord()
        {
            applicationWord = new Application();
            applicationWord.Visible = false;
        }

        /// <summary>
        /// Used to close office word
        /// </summary>
        public void CloseWord()
        {
            applicationWord.Quit(false);
        }

        /// <summary>
        /// Used to replace bookmark with text
        /// </summary>
        private void ReplaceText(string bookmark, string text)
        {
            // Finds a bookmark in a word document and replaces it with text
            if (document.Bookmarks.Exists(bookmark))
            {
                object oBookMark = bookmark;
                document.Bookmarks.get_Item(ref oBookMark).Range.Text = text;
            }
        }

        /// <summary>
        /// Used to create a invoice document based on reservation
        /// </summary>
        private void CreateInvoice(Reservation reservation)
        {
            Customer customer = reservation.Customer;
            Room room = reservation.Room;
            string days = reservation.GetTimeSpan().ToString() + " dage";
            int timespan = reservation.GetTimeSpan();

            // Sets discount if the customer has been on the hotel more than 7 days
            room.SetDiscount(reservation.GetTimeSpan(), 7, 10.0);

            // Customer infomation
            ReplaceText("NAVN", customer.FirstName + " " + customer.LastName);
            ReplaceText("ADRESSE", customer.Address);
            ReplaceText("BY", customer.City);
            ReplaceText("POSTNUMMER", customer.Postal);
            ReplaceText("LAND", customer.Country);

            // Order infomation
            ReplaceText("ID", reservation.OrderNumber.ToString());
            ReplaceText("B_DATO", reservation.ResevationDate.ToShortDateString());
            ReplaceText("A_DATO", reservation.StartDate.ToShortDateString());
            ReplaceText("S_DATO", reservation.EndDate.ToShortDateString());

            // Room infomation
            ReplaceText("BESKRIVELSE_1", "Hotel værelse nr. " + room.Number.ToString());
            ReplaceText("DAGE_1", days);
            ReplaceText("PRIS_1", room.GetRoomPrice(1));
            ReplaceText("S_PRIS_1", room.GetRoomPrice(timespan));

            // Additions infomation
            ReplaceText("BESKRIVELSE_2", "Dine tillægsydelser: " + room.AdditionsDescription);
            ReplaceText("DAGE_2", days);
            ReplaceText("PRIS_2", room.GetAdditionPrice(1));
            ReplaceText("S_PRIS_2", room.GetAdditionPrice(timespan));

            // Price total
            ReplaceText("SAMLEDEPRIS", room.GetTotalPrice(timespan));
        }
    }
}