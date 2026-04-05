namespace Contact_Management_System.DataAccessLayer.Modals
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }

    }
}
