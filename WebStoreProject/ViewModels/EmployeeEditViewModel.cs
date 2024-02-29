namespace WebStoreProject.ViewModels
{
	public class EmployeeEditViewModel
	{
		public int Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
		public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public int Experience { get; set; }

    }
}
