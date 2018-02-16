using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace DataObject.EFCore
{
    public class Product:IProduct
    {

        //Add your own implementation below

        public IEnumerable<Products> GetAll { get; }
        public Products GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
