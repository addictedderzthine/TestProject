namespace TestProject.Model
{
    public class ValidationError
    {
        public string Propertyname { get; set; }
        public string Message { get; set; }

        public ValidationError(string propertyname, string message)
        {
            Propertyname = propertyname;
            Message = message;
        }
    }
}