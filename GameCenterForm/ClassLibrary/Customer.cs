namespace GameCenterForm.ClassLibrary
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer(string customerID, string name, string nbr, string email)
        {
            CustomerID = customerID;
            Name = name;
            PhoneNumber = nbr;
            Email = email;
        }

    }
}
