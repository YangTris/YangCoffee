using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.IServices
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, long amount);
    }
}
