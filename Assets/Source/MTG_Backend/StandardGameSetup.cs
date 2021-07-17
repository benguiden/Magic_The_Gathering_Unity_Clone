namespace MTG
{
    
    namespace Backend
    {
        
        public static class StandardGameSetup
        {

            public static void Setup()
            {
                
                //Construction
                var playerA = new PlayerRuntime_Standard();
                var playerB = new PlayerRuntime_Standard();

                var playerACards = new PlayerCardRuntimeCollections_Standard();
                var playerBCards = new PlayerCardRuntimeCollections_Standard();
                
                var matchProcessor = new MatchProcessor_Standard();
                var roundProcessor = new RoundProcessor_Standard();

                var turnProcessorPlayerA = new TurnProcessor_Standard();
                var turnProcessorPlayerB = new TurnProcessor_Standard();

                //Injection
                playerA.SetDependency(turnProcessorPlayerA);
                playerA.SetDependency(playerACards);
                
                playerB.SetDependency(turnProcessorPlayerB);
                playerB.SetDependency(playerBCards);

                playerACards.SetDependency(new CardRuntime[0]);
                playerBCards.SetDependency(new CardRuntime[0]);
                
                matchProcessor.SetDependency(roundProcessor);
                roundProcessor.SetDependency(new[] {turnProcessorPlayerA, turnProcessorPlayerB});
                
                turnProcessorPlayerA.SetDependency(playerA);
                turnProcessorPlayerB.SetDependency(playerB);
                
                //Verification
                DependencyVerifying.VerifyDependencies(playerA);
                DependencyVerifying.VerifyDependencies(playerB);
                
                DependencyVerifying.VerifyDependencies(playerACards);
                DependencyVerifying.VerifyDependencies(playerBCards);
                
                DependencyVerifying.VerifyDependencies(matchProcessor);
                DependencyVerifying.VerifyDependencies(roundProcessor);
                
                DependencyVerifying.VerifyDependencies(turnProcessorPlayerA);
                DependencyVerifying.VerifyDependencies(turnProcessorPlayerB);

            }

        }

    }

}
