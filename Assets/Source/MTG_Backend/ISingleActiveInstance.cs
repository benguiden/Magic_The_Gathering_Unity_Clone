using System;
using System.Runtime.Serialization;

namespace MTG.Backend
{
    
    public interface ISingleActiveInstance
    {

        public void SetAsSingleActiveInstance();

    }
    
    [Serializable]
    public class AlreadySingleActiveInstance : Exception
    {
        
        public AlreadySingleActiveInstance()
        {
            throw new NotImplementedException();
        }

        public AlreadySingleActiveInstance(string message) : base(message)
        {
            throw new NotImplementedException();
        }

        public AlreadySingleActiveInstance(string message, Exception inner) : base(message, inner)
        {
            throw new NotImplementedException();
        }

        protected AlreadySingleActiveInstance(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            throw new NotImplementedException();
        }
    }
    
}
