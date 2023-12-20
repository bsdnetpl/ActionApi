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
        //private readonly XmlNodeList subCategory;
        private readonly XmlNodeList producers;
        private readonly XmlNodeList products;

        public ServiceXmlAction(Connect connect)
        {
            doc.Load("xml_action_big.xml");
            mainCategory = doc.GetElementsByTagName("MainCategory");
            // subCategory = doc.GetElementsByTagName("SubCategory");
            producers = doc.GetElementsByTagName("Producer");
            products = doc.GetElementsByTagName("Product");
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
                    await _connect.SaveChangesAsync();
                }
            }
            return true;
        }
        public async Task<bool> AddProducer()
        {
            _connect.Database.ExecuteSqlRaw("TRUNCATE TABLE producers");
            Producer producer = new Producer();
            foreach (XmlNode Producer in producers)
            {
                producer.id = Producer.Attributes["id"].Value;
                producer.name = Producer.Attributes["name"].Value;
                await _connect.producers.AddAsync(producer);
                await _connect.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> AddProduct()
        {
            _connect.Database.ExecuteSqlRaw("TRUNCATE TABLE product");
            Product product = new Product();
            
            foreach (XmlNode prod in products)
            {
                if (Convert.ToInt32(prod.Attributes["available"].Value) == 0)
                {
                    continue;
                }
                if(prod.Attributes["name"].Value.Contains("WYPRZEDA"))
                {
                    continue;
                }
                product.id = prod.Attributes["id"].Value;
                product.EAN = prod.Attributes["EAN"].Value;
                product.producer = prod.Attributes["producer"].Value;
                product.name = prod.Attributes["name"].Value;
                product.categoryId = prod.Attributes["categoryId"].Value;
                product.warranty = prod.Attributes["warranty"].Value;
                product.priceNet = Convert.ToDouble(prod.Attributes["priceNet"].Value.Replace(".", ","));
                product.vat = Convert.ToInt32(prod.Attributes["vat"].Value);
                product.pkwiu = prod.Attributes["pkwiu"].Value;
                product.available = Convert.ToInt32(prod.Attributes["available"].Value);
                product.manufacturerPartNumber = prod.Attributes["manufacturerPartNumber"].Value;
                product.sizeWidth = Convert.ToInt32(prod.Attributes["sizeWidth"].Value);
                product.sizeLength = Convert.ToInt32(prod.Attributes["sizeLength"].Value);
                product.sizeHeight = Convert.ToInt32(prod.Attributes["sizeHeight"].Value);
                product.weight = Convert.ToInt32(prod.Attributes["weight"].Value);

                XmlNodeList ImageNode = prod.SelectNodes("Images/Image");
                int licznik = 0;
                foreach (XmlNode img in ImageNode)
                {
                    if (licznik >= 5)
                    {
                        break;
                    }
                    switch (licznik)
                    {
                        case 0:
                            product.urlImg1 = img.Attributes["url"].Value;
                            break;
                        case 1:
                            product.urlImg2 = img.Attributes["url"].Value;
                            break;
                        case 2:
                            product.urlImg3 = img.Attributes["url"].Value;
                            break;
                        case 3:
                            product.urlImg4 = img.Attributes["url"].Value;
                            break;
                        case 4:
                            product.urlImg5 = img.Attributes["url"].Value;
                            break;
                    }
                    licznik++;
                }
                foreach (XmlNode ValueNode in prod.SelectNodes("TechnicalSpecification/Section/Attributes/Attribute"))
                {
                    string Atribute = ValueNode.Attributes["name"].Value;
                    foreach (XmlNode ValueNode2 in ValueNode.SelectNodes("Values/Value"))
                    {
                        string ValueAtrr = ValueNode2.Attributes["Name"].Value;
                        product.description += $"{Atribute} : {ValueAtrr} ";

                    }
                }
                
                await _connect.product.AddAsync(product);
                await _connect.SaveChangesAsync();
                product.description = "";
            }

            return true;
        }

    }
}
