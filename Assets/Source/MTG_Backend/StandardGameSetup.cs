using UnityEngine;

namespace MTG.Backend
{

    public static class StandardGameSetup
    {

        public static void Setup()
        {

            //Construction
            var playerA = new PlayerRuntime_Standard();
            var playerB = new PlayerRuntime_Standard();

            var playerAZones = new PlayerZones_Standard();
            var playerBZones = new PlayerZones_Standard();

            var matchProcessor = new MatchProcessor_Standard();
            var roundProcessor = new RoundProcessor_Standard();

            var turnProcessorPlayerA = new TurnProcessor_Standard();
            var turnProcessorPlayerB = new TurnProcessor_Standard();

            //Injection
            playerA.SetDependency(turnProcessorPlayerA);
            playerA.SetDependency(playerAZones);

            playerB.SetDependency(turnProcessorPlayerB);
            playerB.SetDependency(playerBZones);

            matchProcessor.SetDependency(roundProcessor);
            roundProcessor.SetDependency(matchProcessor);
            roundProcessor.SetDependency(new[] {turnProcessorPlayerA, turnProcessorPlayerB});

            turnProcessorPlayerA.SetDependency(playerA);
            turnProcessorPlayerA.SetDependency(roundProcessor);
            turnProcessorPlayerB.SetDependency(playerB);
            turnProcessorPlayerB.SetDependency(roundProcessor);

            //Verification
            DependencyVerifying.VerifyDependencies(playerA);
            DependencyVerifying.VerifyDependencies(playerB);

            DependencyVerifying.VerifyDependencies(matchProcessor);
            DependencyVerifying.VerifyDependencies(roundProcessor);

            DependencyVerifying.VerifyDependencies(turnProcessorPlayerA);
            DependencyVerifying.VerifyDependencies(turnProcessorPlayerB);

            //Start
            matchProcessor.StartMatch();
        }

        [UnityEditor.MenuItem("Temp/Test Setup")]
        private static void TestSetup()
        {
            if (Application.isPlaying)
                Setup();
        }

    }
    
}
