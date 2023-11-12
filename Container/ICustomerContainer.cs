using Microsoft.EntityFrameworkCore;
using SalesOrdersAPI.Entity;
using SalesOrdersAPI.Models;

namespace SalesOrdersAPI.Container
{
    public interface ICustomerContainer
    {
        Task<List<CustomerEntity>> Getall();
        Task<CustomerEntity> Getbycode(string code);
    }
}
