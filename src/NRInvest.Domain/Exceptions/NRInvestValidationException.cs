using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NRInvest.Domain.Exceptions
{
    public sealed class NRInvestValidationException : ValidationException
    {
        public NRInvestValidationException(IEnumerable<string> messages) 
            : base(string.Join(Environment.NewLine, messages)) { }
    }
}