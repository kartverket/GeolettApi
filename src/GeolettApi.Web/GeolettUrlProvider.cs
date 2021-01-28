using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using GeolettApi.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;

namespace Geonorge.TiltaksplanApi.Web
{
    public class GeolettUrlProvider : IUrlProvider
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IConfiguration _config;

        public GeolettUrlProvider(
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory urlHelperFactory,
            IConfiguration config)
        {
            _actionContextAccessor = actionContextAccessor;
            _urlHelperFactory = urlHelperFactory;
            _config = config;
        }
    
        public ExpandoObject ApiUrls()
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

            dynamic apiUrls = new ExpandoObject();

            apiUrls.registerItem = new ExpandoObject();
            apiUrls.registerItem.get = GetControllerUrl(urlHelper, "GetById", "RegisterItem", new { id = 0 });
            apiUrls.registerItem.getAll = GetControllerUrl(urlHelper, "GetAll", "RegisterItem");
            apiUrls.registerItem.create = GetControllerUrl(urlHelper, "Create", "RegisterItem");
            apiUrls.registerItem.update = GetControllerUrl(urlHelper, "Update", "RegisterItem", new { id = 0 });
            apiUrls.registerItem.patch = GetControllerUrl(urlHelper, "Patch", "RegisterItem", new { id = 0 });
            apiUrls.registerItem.delete = GetControllerUrl(urlHelper, "Delete", "RegisterItem", new { id = 0 });

            apiUrls.dataSet = new ExpandoObject();
            apiUrls.dataSet.get = GetControllerUrl(urlHelper, "GetById", "DataSet", new { id = 0 });
            apiUrls.dataSet.getAll = GetControllerUrl(urlHelper, "GetAll", "DataSet");

            apiUrls.setup = new ExpandoObject();
            apiUrls.setup.get = GetControllerUrl(urlHelper, "Get", "Setup");

            apiUrls.user = new ExpandoObject();
            apiUrls.user.get = GetControllerUrl(urlHelper, "Get", "User");

            return apiUrls;
        }

        private string GetControllerUrl(IUrlHelper urlHelper, string action, string controller, object values = null)
        {
            var url = urlHelper.Action(new UrlActionContext
            {
                Action = action,
                Controller = controller,
                Values = values,
                Protocol = GetProtocol(),
                Host = GetHost()
            });

            var uri = new Uri(url);
            var parameters = GetParameters(values);
            var counter = 0;
            var localPath = Regex.Replace(uri.LocalPath, @"\d+", m => $"{{{parameters[counter++]}}}", RegexOptions.IgnoreCase);

            return $"{GetProtocol()}://{GetHost()}{localPath}";
        }

        private static List<string> GetParameters(object values)
        {
            return values != null ?
                values.GetType().GetProperties()
                    .Select(prop => char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1))
                    .ToList() :
                new List<string>();
        }

        private string GetProtocol()
        {
            return _config.GetValue<string>("Protocol");
        }

        private string GetHost()
        {
            return _actionContextAccessor.ActionContext.HttpContext.Request.Host.Value;
        }
    }
}
