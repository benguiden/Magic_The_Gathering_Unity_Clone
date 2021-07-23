using System.Collections.Generic;

namespace MTG.Backend
{

    public interface ITurnProcessorsDependencies : IDependency
    {

        void SetDependency(IEnumerable<TurnProcessor> turnProcessors);

        [Dependency] IEnumerable<TurnProcessor> TurnProcessorsDependency { get; }

    }

}
