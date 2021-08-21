using System.Collections.Generic;
using MTG.Backend.Editor;

namespace MTG.Backend
{
    
    public abstract partial class PhaseStep : IDebuggableProcessor
    {
        
        public IEnumerable<IDebuggableProcessor> GetDebuggableChildren()
        {
            return new IDebuggableProcessor[0];
        }
        
        public string DebuggingHeaderString => DebuggableProcessor_Helper.GetProcessorTypeName(this);
        
        public bool DebuggingIsActive => ActiveInstance == this;
        
    }
    
}