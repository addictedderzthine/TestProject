using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataObject;
using TestProject.Dto;
using TestProject.Model;

namespace TestProject.Service
{
    public class ProductService
    {
        private readonly IProduct _product;
        public ProductService(IProduct product) => _product = product;

        public void CreateProduct(ProductDto products)
        {
            var product = Mapper.Map<ProductDto, Products>(products);
            if (!product.IsValid)
                throw new Exception("Invalid product");
            _product.CreateProduct(product);
        }

        public void UpdateProduct(ProductDto products)
        {
            var product = Mapper.Map<ProductDto, Products>(products);
            if (!product.IsValid)
                throw new Exception("Invalid product");
            _product.UpdateProduct(product);
        }


        public IEnumerable<ProductDto> GetAll()
        {
            var prod=_product.GetAll;
            var product = Mapper.Map<IEnumerable<Products>, IEnumerable<ProductDto>>(prod);
            return product;
        }

        public ProductDto GetProductById(int id)
        {
            var prod = _product.GetProductById(id);
            var product = Mapper.Map<Products, ProductDto >(prod);
            return product;
        }

        
    }
}


