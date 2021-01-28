using GeolettApi.Application.Models;
using System;
using System.Collections.Generic;

namespace GeolettApi.Application.Exceptions
{
    public class InvalidModelException : Exception
    {
        public List<ErrorViewModel> Errors { get; private set; }

        public InvalidModelException(List<ErrorViewModel> errors)
        {
            Errors = errors;
        }
    }
}
