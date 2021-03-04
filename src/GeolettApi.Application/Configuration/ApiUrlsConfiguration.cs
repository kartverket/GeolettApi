using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolettApi.Application.Configuration
{
    public class ApiUrlsConfiguration
    {
        public static string SectionName => "ApiUrls";
        public string Organizations { get; set; }
    }
}
