using CRM.Models;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Types;

namespace CRM.Repositories
{
    public class ProductRepository
    {
        public IEnumerable<ProductCategory> ListOfProductsCategories()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_productsCategory", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<ProductCategory>("System.ProductsCategoryList", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }

        public IEnumerable<Product> ListOfProducts()
        {
            using (OracleConnection SQLConnect =
                 new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                var p = new OracleDynamicParameters();
                p.Add("p_products", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);

                var myRefcurs = SQLConnect.Query<Product>("System.ProductsList", param : p,
                    commandType: CommandType.StoredProcedure);
                return myRefcurs;
            }
        }

        public void AddProduct(Product newProduct)
        {
            using (OracleConnection SQLConnect =
         new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                SQLConnect.Execute("Add_Product",
                new
                {
                    IC_Name = newProduct.Name
                ,
                    IC_Category = newProduct.Category
                ,
                    IC_Price = newProduct.Price
                ,
                    IC_Quantity = newProduct.Quantity
                }, commandType: CommandType.StoredProcedure);
            }
        }




    }
}