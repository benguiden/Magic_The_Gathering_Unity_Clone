using System.Collections.Generic;

namespace MTG.Backend.Editor
{
    
    public interface IDebuggableProcessor
    {

        public IEnumerable<IDebuggableProcessor> GetDebuggableChildren();

        public string DebuggingHeaderString { get; }
        
        public bool DebuggingIsActive { get; }

    }

    public static class DebuggableProcessor_Helper
    {

        public static string GetProcessorTypeName(IDebuggableProcessor processor)
        {
            return processor.GetType().Name;
        }
        
    }
    
}
