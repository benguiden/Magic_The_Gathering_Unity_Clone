using System;
using System.Runtime.Serialization;

namespace MTG.Backend
{
    
    public class MissingDependencyException : Exception
    {

        public MissingDependencyException()
        {
            throw new NotImplementedException();
        }

        public MissingDependencyException(string message) : base(message)
        {
            throw new NotImplementedException();
        }

        public MissingDependencyException(string message, Exception inner) : base(message, inner)
        {
            throw new NotImplementedException();
        }

        protected MissingDependencyException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            throw new NotImplementedException();
        }

    }
    
}
