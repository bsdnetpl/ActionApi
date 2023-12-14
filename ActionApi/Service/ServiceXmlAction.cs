using ActionApi.DB;
using ActionApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ActionApi.Service
{
    public class ServiceXmlAction : IServiceXmlAction
    {
        private readonly Connect _connect;
        private readonly XmlDocument doc = new XmlDocument();
        private readonly XmlNodeList mainCategory;
        private readonly XmlNodeList subCategory;
        private readonly XmlNodeList producer;
        private readonly XmlNodeList product;

        public ServiceXmlAction(Connect connect)
        {
            doc.Load("xml_action_big.xml");
            mainCategory = doc.GetElementsByTagName("MainCategory");
            subCategory = doc.GetElementsByTagName("SubCategory");
            producer = doc.GetElementsByTagName("Producer");
            product = doc.GetElementsByTagName("Product");
            _connect = connect;
        }


        public async Task<bool> AddMainCategory()
        {
            _connect.Database.ExecuteSqlRaw("TRUNCATE TABLE mainCategories");

            MainCategory mainCat = new MainCategory();

            foreach (XmlNode node in mainCategory)
            {
                mainCat.ids = new Guid();
                mainCat.idntification = node.Attributes["id"].Value;
                mainCat.name = node.Attributes["name"].Value;
                mainCat.description = node.Attributes["name"].Value;
                mainCat.margin = 25;
                mainCat.export = true;
                await _connect.mainCategories.AddAsync(mainCat);
                await _connect.SaveChangesAsync();

            }
            return true;
        }
        public async Task<bool> AddSubCategory()
        {
            _connect.Database.ExecuteSqlRaw("TRUNCATE TABLE subCategories");
            SubCategory subCat = new SubCategory();
            foreach (XmlNode node in mainCategory)
            {
              XmlNode subCategoriesNode = node.SelectSingleNode("SubCategories");

                if (subCategoriesNode != null)
                {
                    return false;
                }

                foreach (XmlNode subCategoryNode in subCategoriesNode.ChildNodes)
                {
                    subCat.idMainCategory = node.Attributes["id"].Value;
                    subCat.name = subCategoryNode.Attributes["name"].Value;
                    subCat.id = subCategoryNode.Attributes["id"].Value;
                    subCat.export = true;
                    subCat.margin = 25;
                    subCat.description = subCategoryNode.Attributes["name"].Value;
                    await _connect.subCategories.AddAsync(subCat);
                    _connect.SaveChanges();
                }
            }
            return true;
        }
    }
}
