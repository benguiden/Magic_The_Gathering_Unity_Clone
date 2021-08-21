using System.Collections.Generic;
using MTG.Backend.Editor;

namespace MTG.Backend
{
    
    public abstract partial class TurnProcessor : IDebuggableProcessor
    {

        public IEnumerable<IDebuggableProcessor> GetDebuggableChildren()
        {
            var debuggableChildren = new IDebuggableProcessor[m_phases.Length];

            for (int i = 0; i < m_phases.Length; i++)
            {
                debuggableChildren[i] = m_phases[i];
            }

            return debuggableChildren;
        }
        
        public string DebuggingHeaderString => DebuggableProcessor_Helper.GetProcessorTypeName(this);
        
        public bool DebuggingIsActive => ActiveInstance == this;

    }
    
}