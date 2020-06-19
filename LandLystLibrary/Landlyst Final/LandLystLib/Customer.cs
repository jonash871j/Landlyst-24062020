namespace LandLystLib
{
	public class Customer
    {
		private string firstName, lastName;
		private string address;
		private string city;
		private string postal;
		private string country;
		private string email;
		private string phoneNumber;

		public string FirstName
		{
			get { return firstName; }
		}
		public string LastName
		{
			get { return lastName; }
		}
		public string Address
		{
			get { return address; }
		}
		public string City
		{
			get { return city; }
		}
		public string Postal
		{
			get { return postal; }
		}
		public string Country
		{
			get { return country; }
		}
		public string Email
		{
			get { return email; }
		}
		public string PhoneNumber
		{
			get { return phoneNumber; }
		}

		public Customer(string firstName, string lastName, string address, string city, string postal, string country,  string email, string phoneNumber)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.address = address;
			this.city = city;
			this.postal = postal;
			this.country = country;
			this.email = email;
			this.phoneNumber = phoneNumber;
		}
	}
}
