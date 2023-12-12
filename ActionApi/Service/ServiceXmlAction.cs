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


        public bool AddMainCategory()
        {
            _connect.Database.ExecuteSqlRaw("TRUNCATE TABLE mainCategories");
            _connect.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.mainCategories ON");
            MainCategory mainCat = new MainCategory();
           
            foreach (XmlNode node in mainCategory)
            {
              
                mainCat.id = node.Attributes["id"].Value;
                mainCat.name = node.Attributes["name"].Value;
                mainCat.description = node.Attributes["name"].Value;
                _connect.mainCategories.Add(mainCat);
                _connect.SaveChanges();
                
            }
            _connect.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.mainCategories OFF");
            return true;
        }
    }
}
