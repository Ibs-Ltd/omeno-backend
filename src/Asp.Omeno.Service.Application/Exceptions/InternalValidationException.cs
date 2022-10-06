using Asp.Omeno.Service.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Omeno.Service.Application.Exceptions
{
    public class InternalValidationException : Exception
    {
        public InternalValidationException(IList<string> errors) : base(ValidatorMessages.Errors(errors))
        {

        }
    }
}
