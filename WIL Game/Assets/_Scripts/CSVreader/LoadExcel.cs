using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoadExcel : MonoBehaviour
{
    public ScenarioItems blankItem;
    public List<ScenarioItems> scenarioDatabase = new List<ScenarioItems>();

    public void LoadScenarioData()
    {
        //clear scenario database
        scenarioDatabase.Clear();
        
        //read CSV files
        List<Dictionary<string, object>> data = CSVreader.Read("scenarioDatabase");
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
        ScenarioItems tempItem = new ScenarioItems(blankItem);

        tempItem.id = id;
        tempItem.scenario = scenario;
        tempItem.difficulty = difficulty;
        tempItem.cleanScore = cleanScore;
        tempItem.controversialScore = controversialScore;
        
        scenarioDatabase.Add(tempItem);

    }
}
