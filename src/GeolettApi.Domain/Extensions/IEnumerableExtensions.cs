﻿using GeolettApi.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeolettApi.Domain.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectOption> ToSelectOptions(this int[] values)
        {
            return values
                .ToList()
                .Select(value =>
                {
                    return new SelectOption
                    {
                        Value = value,
                        Label = value.ToString()
                    };
                });
        }
    }
}
