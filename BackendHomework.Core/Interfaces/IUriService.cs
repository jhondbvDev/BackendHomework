using System;
using System.Collections.Generic;
using System.Text;

namespace BackendHomework.Core.Interfaces
{
    public interface  IUriService
    {
        public Uri GetPageUri(IPaginationFilter filter, string route);
    }
}
