﻿using SalesOrdersAPI.Entity;

namespace SalesOrdersAPI.Container
{
    public interface IMasterContainer
    {
        Task<List<VariantEntity>> GetAllVariant(string variantType);
        Task<List<CategoryEntity>> GetCategory();
    }
}
