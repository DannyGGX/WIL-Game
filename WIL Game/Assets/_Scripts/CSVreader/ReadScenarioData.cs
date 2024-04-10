using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// https://www.youtube.com/watch?v=C37C2yCUlCM&amp;t=448s
/// works with csv reader to load scenario data
/// </summary>
public class ReadScenarioData
{
    private Scenario blankItem;
    private Scenarios scenarios;
    private const string fileName = "Scenario_Database";

    public Scenarios GetScenariosReference()
    {
        return scenarios;
    }

    public void LoadScenarioData()
    {
        var rawData = CSVreader.ReadCsv(fileName);
        scenarios = new Scenarios();
        
        // for loop of raw data starting from index 1 to skip the header
        for (int i = 1; i < rawData.Count - 1; i++)
        {
            AddItem(int.Parse(rawData[i][1])
                , rawData[i][2]
                , int.Parse(rawData[i][3])
                , int.Parse(rawData[i][4])
                , int.Parse(rawData[i][5]));
        }

    }
    
    void AddItem(int id, string scenario, int difficulty, int cleanScore, int controversialScore)
    {
        Scenario tempItem = new Scenario(id, FormatScenarioText(scenario), difficulty, cleanScore, controversialScore);
        
        scenarios.AddScenario(tempItem);
        
    }

    private string FormatScenarioText(string scenarioText)
    {
        if(scenarioText[0] == '\"' && scenarioText[^1] == '\"') // if the text starts and ends with quotes
        {
            // remove the quotes at the start and end
            scenarioText = scenarioText.Remove(0, 1);
            scenarioText = scenarioText.Remove(scenarioText.Length - 1, 1);
            
            // remove the extra quotes in the middle
            // loop twice
            for (int i = 0; i < 2; i++)
            {
                scenarioText = scenarioText.Replace("\"\"", "\"");
            }
        }
        return scenarioText;
    }
}
