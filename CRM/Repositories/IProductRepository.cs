using System.Collections.Generic;

namespace CRM.Repositories
{
    internal interface IProductRepository
    {
        void AddProduct(Models.Product newProduct);

        //IEnumerable<Models.Product> ListOfProducts();
        IEnumerable<Models.Product> ListOfProducts(string toSearch, int? categoryId);

        IEnumerable<Models.ProductCategory> ListOfProductsCategories();
    }
}