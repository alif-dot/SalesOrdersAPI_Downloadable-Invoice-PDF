using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrdersAPI.Entity;
using SalesOrdersAPI.Models;

namespace SalesOrdersAPI.Container
{
    public class CustomerContainer : ICustomerContainer
    {

        private readonly Sales_DBContext _DBContext;
        private readonly IMapper mapper;
        public CustomerContainer(Sales_DBContext dBContext, IMapper mapper)
        {

            this._DBContext = dBContext;
            this.mapper = mapper;
        }

        public async Task<List<CustomerEntity>> Getall()
        {
            var customerdata = await this._DBContext.TblCustomers.ToListAsync();
            if (customerdata != null && customerdata.Count > 0)
            {
                // we need use automapper

                return this.mapper.Map<List<TblCustomer>, List<CustomerEntity>>(customerdata);
            }
            return new List<CustomerEntity>();

        }

        public async Task<CustomerEntity> Getbycode(string code)
        {
            string c = Convert.ToString(code);
            var customerdata = await this._DBContext.TblCustomers.FirstOrDefaultAsync(item => item.Code == code);
            if (customerdata != null)
            {
                return this.mapper.Map<TblCustomer, CustomerEntity>(customerdata);
            }
            return new CustomerEntity();

        }

        //public async Task<CustomerEntity> Getbycode(string code)
        //{
        //    if (int.TryParse(code, out int customerCode))
        //    {
        //        var customerdata = await this._DBContext.TblCustomers.FirstOrDefaultAsync(item => item.Code == customerCode.ToString());
        //        if (customerdata != null)
        //        {
        //            return this.mapper.Map<TblCustomer, CustomerEntity>(customerdata);
        //        }
        //    }

        //    return new CustomerEntity();
        //}
    }
}
