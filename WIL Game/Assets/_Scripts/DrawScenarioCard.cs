using System;
using System.Linq;

public class DrawScenarioCard
{
    private Scenarios scenarios;
    
    public DrawScenarioCard(Scenarios scenarios)
    {
        this.scenarios = scenarios;
    }
    
    public Scenario GetRandomScenario()
    {
        int random = UnityEngine.Random.Range(0, scenarios.GetScenariosCount());
        return scenarios.GetScenario(random);
    }
    
    public Scenario GetSpecificScenario(int id)
    {
        return scenarios.GetScenario(id);
    }

    public Scenario GetRandomScenarioOfDifficulty(int difficultyLevel)
    {
        var scenarioIdsInDifficultyLevel = scenarios.GetScenarioIdsByDifficulty(difficultyLevel);
        int random = UnityEngine.Random.Range(0, scenarioIdsInDifficultyLevel.Count);
        return scenarios.GetScenario(scenarioIdsInDifficultyLevel.ElementAt(random));
    }
    
}