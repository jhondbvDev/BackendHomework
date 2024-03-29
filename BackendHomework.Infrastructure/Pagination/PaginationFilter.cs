﻿using BackendHomework.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendHomework.Infrastructure.Pagination
{
    public class PaginationFilter: IPaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 50 ? 50 : pageSize;
        }
    }
}
