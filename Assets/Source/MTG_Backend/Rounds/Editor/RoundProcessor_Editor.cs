using System.Collections.Generic;
using MTG.Backend.Editor;

namespace MTG.Backend
{
    
    public abstract partial class RoundProcessor : IDebuggableProcessor
    {
        
        public IEnumerable<IDebuggableProcessor> GetDebuggableChildren()
        {
            var debuggableChildren = new IDebuggableProcessor[m_turns.Length];

            for (int i = 0; i < m_turns.Length; i++)
            {
                debuggableChildren[i] = m_turns[i];
            }
            
            return debuggableChildren;
        }
        
        public string DebuggingHeaderString => DebuggableProcessor_Helper.GetProcessorTypeName(this);
        
        public bool DebuggingIsActive => ActiveInstance == this;
        
    }
    
}