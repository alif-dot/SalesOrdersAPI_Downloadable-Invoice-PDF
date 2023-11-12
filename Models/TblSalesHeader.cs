﻿using System;
using System.Collections.Generic;

namespace SalesOrdersAPI.Models
{
    public partial class TblSalesHeader
    {
        public string InvoiceNo { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public string CustomerId { get; set; } = null!;
        public string? CustomerName { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Remarks { get; set; }
        public decimal? Total { get; set; }
        public decimal? Tax { get; set; }
        public decimal? NetTotal { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ModifyUser { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
