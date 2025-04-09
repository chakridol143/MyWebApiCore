using MyWebApiCoreService.Models;

namespace MvcDHProject.Models
{
    public interface ICustomerDal
    {
        List<CUSTOMER> Customers_Select();
        CUSTOMER Customer_Select(int CustId);
        void Customer_Insert(CUSTOMER customer);
        void Customer_Update(CUSTOMER customer);
        void Customer_Delete(int CustId);
    }
}
