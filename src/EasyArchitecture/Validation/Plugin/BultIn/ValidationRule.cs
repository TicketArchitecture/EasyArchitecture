using System;

namespace EasyArchitecture.Validation.Plugin.BultIn
{
    internal class ValidationRule<T>
    {
        public Func<T, bool> Rule { get; set; }
        public string Message { get; set; }
    }
}