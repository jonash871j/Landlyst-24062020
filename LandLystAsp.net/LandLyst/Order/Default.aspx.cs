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
            if (Request["SDate"] == new DateTime().ToString("dd-MM-yyyy")
                Request["LDate"] == new DateTime().ToString("dd-MM-yyyy")
                string.IsNullOrEmpty(Request["SDate"]) ||
                string.IsNullOrEmpty(Request["LDate"]))
                Response.Redirect(@"..\Booking");
        }

        protected void bn_reserve_Click(object sender, EventArgs e)
        {
            try
            {
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
                    Convert.ToDateTime(Request["EDate"])
                );
                reception.CreateReservation(reservation);
            }
            catch (Exception exception)
            {
                lb_error.Text = exception.Message;
            }
        }
    }
}