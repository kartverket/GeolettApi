using System.Dynamic;

namespace GeolettApi.Application
{
    public interface IUrlProvider
    { 
        ExpandoObject ApiUrls();
    }
}
