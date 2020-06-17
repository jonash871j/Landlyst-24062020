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

        protected void Page_Load(object sender, EventArgs e)
        {
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
                Response.Redirect(@"..\Booking");
            }
            catch (Exception)
            {
                Response.Redirect(@"..\Booking");
                throw;
            }




        }

        protected void bn_reserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (ErrorFound())
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
                reception.SendOrder(reservation);
                Response.Redirect(@"..\Confirmed.aspx");

            }
            catch (Exception exception)
            {
                lb_error.Text = exception.Message;
            }
        }

        bool ErrorFound()
        {
            if (reception.CheckEmailExists(tb_email.Text))
                lb_error.Text = "Email eksitere allerede!!!";
            else
                return false;
            return true;
        }

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
                Customer customer = reception.GetCustomer(tb_emailExist.Text);
                Reservation reservation = new Reservation(
                    customer,
                    reception.GetRoom(int.Parse(Request["Room"])),
                    Convert.ToDateTime(Request["SDate"]),
                    Convert.ToDateTime(Request["LDate"])
                );
                reception.CreateReservation(reservation);
                reception.SendInvoice(reservation, @"C:\Users\seba6474\Documents\GitHub\Landlyst3\LandLystAsp.net\LandLyst\", "Skabalon.docx");
                Response.Redirect(@"..\Confirmed.aspx");
            }
            catch (Exception exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "VeiwBox", "VeiwBox(0, 'NotNewCustomerBox', 'NewCustomerBox')", true);
                lb_error.Text = exception.Message;
            }
        }

        protected void Label1_Load(object sender, EventArgs e)
        {
            Room room = reception.GetRoom(Int32.Parse(Request["Room"]));
            List<RoomAddition> roomAdditions = room.Additions;

            string roomAdditionstext = "";
            foreach (var item in roomAdditions)
            {
                roomAdditionstext += $"{item.Addtion} ";
            }
            Label1.InnerHtml = $"Værelse nr: {room.Number} <br />Værelses Tillæg: {roomAdditionstext}<br />Start Dato: {Request["SDate"]}<br />Slut Dato: {Request["LDate"]}<br />";
            Label1.InnerHtml += "Alle hotels værelser. Har hver især med et unikt præg. Der er kælet for hver en detalje alle rum, og alle værelser har eget bad, toilet og adgang til WI-FI.";
        }
    }
}