namespace StudentManagement.WebAPI.Models
{
    public class SearchStudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateUserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public  string ConfirmPassword { get; set; }
    }
}
