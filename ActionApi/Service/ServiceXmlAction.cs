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
        public async Task<bool> GetSubCategory()
        {
            SubCategory subCat = new SubCategory();
            foreach (XmlNode node in mainCategory)
            {
                for(int i=0; i > node.ChildNodes.Count; i++)
                {
                    subCat.idMainCategory = node.Attributes["id"].Value;
                    subCat.name = node.ChildNodes[i].Attributes["name"].Value;
                    subCat.export = true;
                    subCat.margin = Convert.ToInt16(node.Attributes["margin"].Value);
                    subCat.description = node.ChildNodes[i].Attributes["name"].Value;
                    //await _connect.subCategories.AddAsync(subCat);
                    //await _connect.SaveChangesAsync();
                }
            }
            return true;
        }
    }
}
