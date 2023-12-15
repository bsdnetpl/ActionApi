
namespace ActionApi.Service
{
    public interface IServiceXmlAction
    {
        Task<bool> AddMainCategory();
        Task<bool> AddProducer();
        Task<bool> AddProduct();
        Task<bool> AddSubCategory();
    }
}