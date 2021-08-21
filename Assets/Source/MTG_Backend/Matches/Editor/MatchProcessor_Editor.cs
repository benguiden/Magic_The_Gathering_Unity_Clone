using System.Collections.Generic;
using MTG.Backend.Editor;

namespace MTG.Backend
{
    
    public abstract partial class MatchProcessor : IDebuggableProcessor
    {
        
        public IEnumerable<IDebuggableProcessor> GetDebuggableChildren()
        {
            return new IDebuggableProcessor[]
            {
                m_roundProcessor
            };
        }

        public string DebuggingHeaderString => DebuggableProcessor_Helper.GetProcessorTypeName(this);

        public bool DebuggingIsActive => ActiveInstance == this;

    }
    
}
