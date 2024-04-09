using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A separated data container for scenarios. This class is also used for basic handling and sorting of scenario data.
/// </summary>
public class Scenarios
{
    public Dictionary<int, Scenario> scenarios { get; private set; } = new(); // <id, scenario>
    
    public Dictionary<int, HashSet<int>> scenariosSortedByDifficulties = new(); // <difficulty, ids>

    public void AddScenario(int id, Scenario scenario)
    {
        scenarios.Add(id, scenario);
    }

    public Scenario GetScenario(int id)
    {
        return scenarios[id];
    }
    
    public int GetScenariosCount()
    {
        return scenarios.Count;
    }

    public int GetScenariosCountByDifficulty(int difficulty)
    {
        return scenariosSortedByDifficulties[difficulty].Count;
    }
    public void SortScenariosByDifficulty()
    {
        scenariosSortedByDifficulties.Clear();
        
        foreach (var scenario in scenarios)
        {
            var currentScenarioDifficulty = scenario.Value.Difficulty;
            if (scenariosSortedByDifficulties.ContainsKey(currentScenarioDifficulty) == false)
            {
                scenariosSortedByDifficulties.Add(currentScenarioDifficulty, new HashSet<int>());
            }
            scenariosSortedByDifficulties[currentScenarioDifficulty].Add(scenario.Key);
        }
        
        scenariosSortedByDifficulties = scenariosSortedByDifficulties
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);
    }
    
    public HashSet<int> GetScenarioIdsByDifficulty(int difficulty)
    {
        return scenariosSortedByDifficulties[difficulty];
    }
    
    public Scenario GetRandomScenarioOfDifficulty(int difficultyLevel)
    {
        var scenarioIdsInDifficultyLevel = GetScenarioIdsByDifficulty(difficultyLevel);
        int random = UnityEngine.Random.Range(0, scenarioIdsInDifficultyLevel.Count);
        return GetScenario(scenarioIdsInDifficultyLevel.ElementAt(random));
    }
}