using System;

namespace EasyArchitecture.Domain
{
    internal class ValidationRule<T>
    {
        public Func<T, bool> Rule { get; set; }
        public string Message { get; set; }
    }
}