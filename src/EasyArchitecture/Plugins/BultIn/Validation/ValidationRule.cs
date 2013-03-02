using System;

namespace EasyArchitecture.Plugins.BultIn.Validation
{
    internal class ValidationRule<T>
    {
        public Func<T, bool> Rule { get; set; }
        public string Message { get; set; }
    }
}