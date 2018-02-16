namespace TestProject.Model
{
    public class Products : EntityBase
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        protected override void Validate()
        {
            //TODO: add more validations
            if (string.IsNullOrEmpty(ProductName)) ValidationErrors.Add("ProductName", "ProductName is Required");

        }
    }
}