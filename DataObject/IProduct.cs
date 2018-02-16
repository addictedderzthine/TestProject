using System.Collections.Generic;
using TestProject.Model;

namespace DataObject
{
    public interface IProduct
    {
        IEnumerable<Products> GetAll { get; }
        Products GetProductById(int id);
        void CreateProduct(Products products);
        void UpdateProduct(Products products);
        void DeleteProduct(int id);
    }
}