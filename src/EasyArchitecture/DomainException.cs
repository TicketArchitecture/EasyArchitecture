using System;
using System.Collections.Generic;

namespace EasyArchitecture
{
    public abstract class DomainException : Exception
    {
        private readonly List<string> _messages = new List<string>();

        protected DomainException()
        {
        }

        protected DomainException(params string[] messages)
        {
            _messages.AddRange(messages);
        }

        public override string Message { get { return string.Join(Environment.NewLine, _messages); } }

    }
}
