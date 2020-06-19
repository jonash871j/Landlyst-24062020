using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LandLystLib;

namespace LandLyst.Order
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static Reception reception = new Reception("Server=127.0.0.1; Port=5432; User Id=postgres; Password=123; Database=Landlyst;");

        //On Page Load, Checks if date and room nr is set and available
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = $"Landlyst - Værelse: {Request["Room"]}";

            if (
                Request["SDate"] == new DateTime().ToString("dd-MM-yyyy") ||
                Request["LDate"] == new DateTime().ToString("dd-MM-yyyy") ||
                string.IsNullOrEmpty(Request["SDate"]) ||
                string.IsNullOrEmpty(Request["LDate"]))
                Response.Redirect(@"..\Booking");

            try
            {
                 if (!reception.CheckAvailableRoom(
                    int.Parse(Request["Room"]),
                    Convert.ToDateTime(Request["SDate"]),
                    Convert.ToDateTime(Request["LDate"])
                ))
                Response.Redirect(@"..\Booking\?e=1");
            }
            catch (Exception)
            {
                Response.Redirect(@"..\Booking");
                throw;
            }
        }

        //on Button click, it will reserve a room thats picked.
        protected void bn_reserve_Click(object sender, EventArgs e)
        {
            if (CheckEmptyTextBox(tb_firstName, "Fornavnet"))          return;
            if (CheckEmptyTextBox(tb_lastName, "Efternavnet"))         return;
            if (CheckEmptyTextBox(tb_phoneNumber, "Telefonnummeret"))  return;
            if (CheckEmptyTextBox(tb_email, "Emailen"))                return;
            if (CheckEmptyTextBox(tb_address, "Adressen"))             return;
            if (CheckEmptyTextBox(tb_postal, "Postnummeret"))          return;
            if (CheckEmptyTextBox(tb_country, "Landet"))               return;
            if (CheckEmptyTextBox(tb_city, "Byen"))                    return;

            try
            {
                if (CheckEmail())
                    return;

                Customer customer = new Customer(
                    tb_firstName.Text,
                    tb_lastName.Text,
                    tb_address.Text,
                    tb_city.Text,
                    tb_postal.Text,
                    tb_country.Text,
                    tb_email.Text,
                    tb_phoneNumber.Text
                );
                reception.CreateCustomer(customer);

                Reservation reservation = new Reservation(
                    customer,
                    reception.GetRoom(int.Parse(Request["Room"])),
                    Convert.ToDateTime(Request["SDate"]),
                    Convert.ToDateTime(Request["LDate"])
                );
                reception.CreateReservation(reservation);
                Response.Redirect(@"..\Confirmed.aspx");

            }
            catch (Exception exception)
            {
                lb_error.Text = exception.Message;
            }
        }
        bool CheckEmptyTextBox(TextBox textBox, string name)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
                return false;
            lb_error.Text = name + " er mangler!";
            return true;
        }


        //ErrorFound, Will Check for errors
        bool CheckEmail()
        {
            if (reception.CheckEmailExists(tb_email.Text))
                lb_error.Text = "Email eksitere allerede!";
            else
                return false;
            return true;
        }

        //on button click, it will reserve a room thats picked, if you allready is a customer
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!reception.CheckEmailExists(tb_emailExist.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "VeiwBox", "VeiwBox(0, 'NotNewCustomerBox', 'NewCustomerBox')", true);
                    lb_error.Text = "Emailen eksitere ikke i systemet!";
                    return;
                }
                if (reception.CheckAvailableRoom(
                    int.Parse(Request["Room"]),
                    Convert.ToDateTime(Request["SDate"]),
                    Convert.ToDateTime(Request["LDate"])
                ))
                {

                    Customer customer = reception.GetCustomer(tb_emailExist.Text);
                    Reservation reservation = new Reservation(
                    customer,
                    reception.GetRoom(int.Parse(Request["Room"])),
                    Convert.ToDateTime(Request["SDate"]),
                    Convert.ToDateTime(Request["LDate"])
                );
                reception.CreateReservation(reservation);
                Response.Redirect(@"..\Confirmed.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "VeiwBox", "VeiwBox(0, 'NotNewCustomerBox', 'NewCustomerBox')", true);
                    lb_error.Text = "Værelset er allerede optaget, prøv et andet værelse";
                    Response.Redirect(@"..\Booking\?e=1");
                }
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "VeiwBox", "VeiwBox(0, 'NotNewCustomerBox', 'NewCustomerBox')", true);
                lb_error.Text = exception.Message;
            }
        }

        //label1_Load, loads data from picked room.
        protected void Label1_Load(object sender, EventArgs e)
        {
            Room room = reception.GetRoom(Int32.Parse(Request["Room"]));
            List<RoomAddition> roomAdditions = room.Additions;
            DateTime StartDate = Convert.ToDateTime(Request["SDate"]);
            DateTime EndDate = Convert.ToDateTime(Request["LDate"]);

            room.SetDiscount((int)(EndDate - StartDate).TotalDays, 7, 10);
            double price = room.TotalPrice * (EndDate - StartDate).TotalDays;

            if (roomAdditions.Count != 0)
            {
                string roomAdditionstext = $"{roomAdditions[0].Addtion} ({roomAdditions[0].Price} kr)";
                for (int i = 1; i < roomAdditions.Count; i++)
                {
                    roomAdditionstext += $", {roomAdditions[i].Addtion} ({roomAdditions[i].Price} kr)";
                }
                Label1.InnerHtml = $"Værelse nr: {room.Number} <br /><b>Pris: {price} kr </b><br />Værelses Tillæg: {roomAdditionstext}<br />Start Dato: {Request["SDate"]}<br />Slut Dato: {Request["LDate"]}<br />";
            }
            else
            {
                Label1.InnerHtml = $"Værelse nr: {room.Number} <br /><b>Pris: {price} kr </b><br />Start Dato: {Request["SDate"]}<br />Slut Dato: {Request["LDate"]}<br />";

            }
            

            Label1.InnerHtml += "Alle hotels værelser. Har hver især med et unikt præg. Der er kælet for hver en detalje alle rum, og alle værelser har eget bad, toilet og adgang til WI-FI.";
        }
    }
}