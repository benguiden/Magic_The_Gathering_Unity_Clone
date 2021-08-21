using System.Collections.Generic;
using MTG.Backend.Editor;

namespace MTG.Backend
{
    
    public abstract partial class TurnPhase : IDebuggableProcessor
    {
        
        public IEnumerable<IDebuggableProcessor> GetDebuggableChildren()
        {
            var debuggableChildren = new IDebuggableProcessor[m_steps.Length];

            for (int i = 0; i < m_steps.Length; i++)
            {
                debuggableChildren[i] = m_steps[i];
            }

            return debuggableChildren;
        }
        
        public string DebuggingHeaderString => DebuggableProcessor_Helper.GetProcessorTypeName(this);
        
        public bool DebuggingIsActive => ActiveInstance == this;
        
    }
    
}