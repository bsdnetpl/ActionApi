
namespace ActionApi.Service
{
    public interface IServiceXmlAction
    {
        Task<bool> AddMainCategory();
        Task<bool> GetSubCategory();
    }
}