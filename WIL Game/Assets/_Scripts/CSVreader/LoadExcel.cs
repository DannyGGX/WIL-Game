using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// https://www.youtube.com/watch?v=C37C2yCUlCM&amp;t=448s
/// works with csv reader to load scenario data
/// </summary>
public class LoadExcel
{
    private Scenario blankItem;
    private Scenarios scenarios;

    public Scenarios GetScenariosReference()
    {
        return scenarios;
    }

    public void LoadScenarioData()
    {
        
        List<Dictionary<string, object>> data = CSVreader.Read("Scenario_Database");
        for (var i = 0; i < data.Count; i++)
        {
            int id = int.Parse(data[i]["id"].ToString(), System.Globalization.NumberStyles.Integer);
            string scenario = data[i]["text"].ToString();
            int difficulty = int.Parse(data[i]["difficulty"].ToString(), System.Globalization.NumberStyles.Integer);
            int cleanScore = int.Parse(data[i]["clean_score"].ToString(), System.Globalization.NumberStyles.Integer);
            int controversialScore = int.Parse(data[i]["controversial_score"].ToString(), System.Globalization.NumberStyles.Integer);

            AddItem(id, scenario, difficulty, cleanScore, controversialScore);
        }
    }
    
    void AddItem(int id, string scenario, int difficulty, int cleanScore, int controversialScore)
    {
        Scenario tempItem = new Scenario(id, scenario, difficulty, cleanScore, controversialScore);
        
        scenarios.AddScenario(tempItem);
    }
}
