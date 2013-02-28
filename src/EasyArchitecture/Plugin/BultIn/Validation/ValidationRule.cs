using System;

namespace EasyArchitecture.Plugin.BultIn.Validation
{
    internal class ValidationRule<T>
    {
        public Func<T, bool> Rule { get; set; }
        public string Message { get; set; }
    }
}