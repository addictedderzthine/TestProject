#region region

using System;
using System.Windows.Forms;
using Autofac;
using DataObject;
using TestProject.Dto;
using TestProject.Service;

#endregion

namespace TestProject.UI
{
    public partial class AddNewProduct : Form
    {
        private readonly int _id;

        //Since this are winforms, you can use a pattern so called MVP
        //So that you can easily unit test the UI if needed 
        public AddNewProduct()
        {
            InitializeComponent();
            buttonSave.Click += ButtonSave_Click;
            buttonCancel.Click += (sender, e) => Close();
        }


        //Constructor for edit/update
        public AddNewProduct(int id) : this() => _id = id;

        private string ProductDescription
        {
            get => textBoxProductDescription.Text;
            set => textBoxProductDescription.Text = value;
        }

        private string productName
        {
            get => textBoxProductName.Text;
            set => textBoxProductName.Text = value;
        }


        public event EventHandler Save;

        protected override void OnLoad(EventArgs e)
        {
            if (_id>0)
                using (var scope = Register.Container.BeginLifetimeScope())
                {
                    var product = scope.Resolve<IProduct>();
                    var getProduct= new ProductService(product).GetProductById(_id);
                    productName = getProduct.ProductName;
                    ProductDescription = getProduct.ProductDescription;
                }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            ProductDto productDto = new ProductDto
            {
                Id = _id,
                ProductName = productName,
                ProductDescription = ProductDescription
            };
            using (var scope = Register.Container.BeginLifetimeScope())
            {
                var product = scope.Resolve<IProduct>();
                if (_id != 0)
                    new ProductService(product).UpdateProduct(productDto);
                else
                    new ProductService(product).CreateProduct(productDto);
            }
            OnSave();
            Close();

        }


        protected virtual void OnSave() => Save?.Invoke(this, EventArgs.Empty);
    }
}
