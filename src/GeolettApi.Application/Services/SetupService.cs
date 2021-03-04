using GeolettApi.Application.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace GeolettApi.Application.Services
{
    public class SetupService : ISetupService
    {
        private readonly IUrlProvider _urlProvider;

        private static readonly ResourceManager _appTextResourceManager =
            new ResourceManager($"{Assembly.GetExecutingAssembly().GetName().Name}.resources.AppTextResource", typeof(AppTextResource).Assembly);

        private static readonly List<CultureInfo> _supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("nb-NO", true)
        };

        public SetupService(
            IUrlProvider urlProvider)
        {
            _urlProvider = urlProvider;
        }

        public SetupViewModel Get()
        {
            return new SetupViewModel
            {
                ApiUrls = _urlProvider.ApiUrls()/*,
                Translations = GetTranslations()*/
            };
        }

        private static List<TranslationViewModel> GetTranslations()
        {
            return _supportedCultures
                .Select(culture =>
                {
                    var resourceSet = _appTextResourceManager.GetResourceSet(culture, true, false);
                    var enumerator = resourceSet.GetEnumerator();
                    var texts = new Dictionary<string, string>();

                    while (enumerator.MoveNext())
                        texts.Add(enumerator.Key.ToString(), enumerator.Value.ToString());

                    return new TranslationViewModel
                    {
                        Culture = culture.Name,
                        Texts = texts
                    };
                })
                .ToList();
        }
    }
}
