using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScenarioItems 
{
    public int id;
    public string scenario;
    public int difficulty;
    public int controversialScore;
    public int cleanScore;
    public char scenarioInclusion;
    
    public ScenarioItems(ScenarioItems d)
    {
        id = d.id;
        scenario = d.scenario;
        difficulty = d.difficulty;
        controversialScore = d.controversialScore;
        cleanScore = d.cleanScore;
        scenarioInclusion = d.scenarioInclusion;
    }
}




