using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareNest_Service_Detail.Infrastructure.ApiEndpoints
{
    public class ServiceEndpoint
    {
        public static string GetById(string? id) => $"/api/service/{id}";
    }
}
