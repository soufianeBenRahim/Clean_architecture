﻿using System;

namespace Ordering.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class ValidationDomainException : Exception
    {
        public ValidationDomainException()
        { }

        public ValidationDomainException(string message)
            : base(message)
        { }

        public ValidationDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
