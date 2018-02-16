#region region

using System.Collections.Generic;
using System.Linq;
using Dapper;
using TestProject.Model;

#endregion

namespace DataObject.Dapper
{
    public class Product:IProduct
    {
        //Queries are generated right inside SQL Server Management Studio using third party extension

        public IEnumerable<Products> GetAll
        {
            get
            {
                //If you dont want to write sql queries manually
                //there's a dapper extension you can add
                // here's the github repo 
                //https://github.com/tmsmith/Dapper-Extensions
                string sql = "SELECT * FROM Products";
                return DapperConnection.TestProj.Query<Products>(sql);
            }
        }

        public Products GetProductById(int id)
        {
            string sql = "SELECT TOP 1 * FROM Products where Id=@Id";
            return DapperConnection.TestProj.Query<Products>(sql, new { Id=id}).FirstOrDefault();
        }

        public void CreateProduct(Products products)
        {
            string sql = @"INSERT INTO dbo.Products
	                        (
		                        ProductName, ProductDescription
	                        )
	                        VALUES
	                        (
		                        @ProductName,
		                        @ProductDescription
	                        )";
            DapperConnection.TestProj.Execute(sql, products);

        }

        public void UpdateProduct(Products products)
        {
            string sql = @"UPDATE dbo.Products
                        SET    ProductName = @ProductName ,
                               ProductDescription = @ProductDescription
                        WHERE  (   Id = @Id);";
            DapperConnection.TestProj.Execute(sql, products);
        }

        public void DeleteProduct(int id)
        {
            string sql = @"DELETE FROM dbo.Products WHERE (Id = @Id)";
            DapperConnection.TestProj.Execute(sql, new {Id=id});
        }
    }
}
