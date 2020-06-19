using System;

namespace LandLystLib
{
	public class Reservation
    {
		private Customer customer;
		private Room room;
		private DateTime resevationDate = DateTime.Now;
		private DateTime startDate;
		private DateTime endDate;
		private int orderNumber;

		public Customer Customer
		{
			get { return customer; }
			internal set { customer = value; }
		}
		public Room Room
		{
			get { return room; }
			internal set { room = value; }
		}
		public DateTime ResevationDate
		{
			get { return resevationDate; }
        }
		public DateTime StartDate
		{
			get { return startDate; }
		}
		public DateTime EndDate
		{
			get { return endDate; }
		}
		public int OrderNumber
		{
			get { return orderNumber; }
			internal set { orderNumber = value; }
		}

		public Reservation(Customer customer, Room room, DateTime startDate, DateTime endDate, int orderNumber = -1)
		{
			this.customer = customer;
			this.room = room;
			this.startDate = startDate;
			this.endDate = endDate;
			this.orderNumber = orderNumber;
        }
		public Reservation(Customer customer, Room room, DateTime startDate, DateTime endDate, DateTime resevationDate, int orderNumber = -1)
			: this(customer, room, startDate, endDate, orderNumber)
		{
			this.resevationDate = resevationDate;
		}

		/// <summary>
		/// Used to get days amount a customer has staid at the hotel
		/// </summary>
		public int GetTimeSpan()
		{
			return (int)(endDate - startDate).TotalDays;
		}

	}
}