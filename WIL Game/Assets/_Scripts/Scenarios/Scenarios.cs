using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A separated data container for scenarios. This class is also used for basic handling and sorting of scenario data.
/// </summary>
public class Scenarios
{
    public Dictionary<int, Scenario> ScenariosCollection { get; private set; } = new(); // <id, scenario>
    
    public Dictionary<int, HashSet<int>> ScenariosSortedByDifficulties = new(); // <difficulty, ids>

    public void AddScenario(Scenario scenario)
    {
        ScenariosCollection.Add(scenario.Id, scenario);
    }

    public Scenario GetScenario(int id)
    {
        return ScenariosCollection[id];
    }
    
    public int GetScenariosCount()
    {
        return ScenariosCollection.Count;
    }

    public int GetScenariosCountByDifficulty(int difficulty)
    {
        return ScenariosSortedByDifficulties[difficulty].Count;
    }
    public void SortScenariosByDifficulty()
    {
        ScenariosSortedByDifficulties.Clear();
        
        foreach (var scenario in ScenariosCollection)
        {
            var currentScenarioDifficulty = scenario.Value.Difficulty;
            if (ScenariosSortedByDifficulties.ContainsKey(currentScenarioDifficulty) == false)
            {
                ScenariosSortedByDifficulties.Add(currentScenarioDifficulty, new HashSet<int>());
            }
            ScenariosSortedByDifficulties[currentScenarioDifficulty].Add(scenario.Key);
        }
        
        ScenariosSortedByDifficulties = ScenariosSortedByDifficulties
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);
    }
    
    public Scenario GetRandomScenarioOfDifficulty(int difficultyLevel)
    {
        var scenarioIdsInDifficultyLevel = ScenariosSortedByDifficulties[difficultyLevel];
        int random = UnityEngine.Random.Range(0, scenarioIdsInDifficultyLevel.Count);
        return GetScenario(scenarioIdsInDifficultyLevel.ElementAt(random));
    }
}