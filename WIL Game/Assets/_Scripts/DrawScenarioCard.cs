using System;
using System.Collections.Generic;
using System.Linq;

public class DrawScenarioCard
{
    private Stack<int> _scenarioIdsStack;
    
    public DrawScenarioCard(Scenarios scenarios)
    {
        CreateRandomisedStackOfIds(ExtractIds(scenarios));
    }

    private HashSet<int> ExtractIds(Scenarios scenarios)
    {
        HashSet<int> scenarioIds = new HashSet<int>();
        foreach (var scenario in scenarios.ScenariosCollection)
        {
            scenarioIds.Add(scenario.Key);
        }
        return scenarioIds;
    }

    private void CreateRandomisedStackOfIds(HashSet<int> scenarioIds)
    {
        _scenarioIdsStack = new Stack<int>();
        while (scenarioIds.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, scenarioIds.Count);
            _scenarioIdsStack.Push(scenarioIds.ElementAt(random));
            scenarioIds.Remove(scenarioIds.ElementAt(random));
        }
    }

    /// <returns> scenario id</returns>
    public int DrawCard()
    {
        return _scenarioIdsStack.Pop();
    }

    public int GetCardCount()
    {
        return _scenarioIdsStack.Count;
    }
    public bool IsDrawCardsEmpty()
    {
        return _scenarioIdsStack.Count == 0;
    }
    
    public void RefillDrawCards(Scenarios scenarios)
    {
        CreateRandomisedStackOfIds(ExtractIds(scenarios));
    }
    
}