using System;
using System.Collections.Generic;
using System.Linq;

public class DrawScenarioCard
{
    private Stack<int> scenarioIdsStack;
    
    public DrawScenarioCard(Scenarios scenarios)
    {
        scenarioIdsStack = CreateRandomisedStackOfIds(ExtractIds(scenarios));
    }

    private HashSet<int> ExtractIds(Scenarios scenarios)
    {
        HashSet<int> scenarioIds = new HashSet<int>();
        for (int i = 0; i < scenarios.GetScenariosCount(); i++)
        {
            scenarioIds.Add(i);
        }
        return scenarioIds;
    }

    private Stack<int> CreateRandomisedStackOfIds(HashSet<int> scenarioIds)
    {
        scenarioIdsStack = new Stack<int>();
        while (scenarioIds.Count > 0)
        {
            int random = UnityEngine.Random.Range(0, scenarioIds.Count);
            scenarioIdsStack.Push(scenarioIds.ElementAt(random));
            scenarioIds.Remove(scenarioIds.ElementAt(random));
        }
        return scenarioIdsStack;
    }

    /// <returns> scenario id</returns>
    public int DrawCard()
    {
        return scenarioIdsStack.Pop();
    }

    public bool HasCards()
    {
        return scenarioIdsStack.Count > 0;
    }

    public int GetCardCount()
    {
        return scenarioIdsStack.Count;
    }
    
}