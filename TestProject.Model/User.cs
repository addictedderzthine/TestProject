using System;

namespace TestProject.Model
{
    public class User : EntityBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;

        protected override void Validate()
        {
            //TODO: add more validations
            if (string.IsNullOrEmpty(UserName)) ValidationErrors.Add("UserName", "Name is Required");
            if (Password.Length <= 2) ValidationErrors.Add("Password", "Password should be atleast 3 characters long");
        }
    }
}