using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// works with csv reader to load scenario data
/// </summary>
public class ReadScenarioData
{
    private Scenarios _scenarios;
    private const string FileName = "Scenario_Database";

    public Scenarios GetScenarioData()
    {
        var rawData = CsvReader.ReadCsv(FileName);
        _scenarios = new Scenarios();
        
        // for loop of raw data starting from index 1 to skip the header
        for (int row = 1; row < rawData.Count; row++)
        {
            if (rawData[row][0] != "y") continue; // load scenarios that are marked as 'y' to be included
            AddItem(int.Parse(rawData[row][1])
                , rawData[row][2]
                , int.Parse(rawData[row][3])
                , int.Parse(rawData[row][4])
                , int.Parse(rawData[row][5]));
        }
        return _scenarios;
    }
    
    private void AddItem(int id, string scenario, int difficulty, int cleanScore, int controversialScore)
    {
        Scenario tempItem = new Scenario(id, FormatCsvString(scenario), difficulty, cleanScore, controversialScore);
        
        _scenarios.AddScenario(tempItem);
        
    }

    /// <summary>
    /// Removes extra quotes from text from the CSV reader.
    /// This occurs if there are text fields in the Excel file that have quotes in them
    /// </summary>
    private static string FormatCsvString(string csvString)
    {
        if (csvString[0] != '\"' || csvString[^1] != '\"') return csvString; // if the text starts and ends with quotes, continue
        
        csvString = csvString.Remove(0, 1);
        csvString = csvString.Remove(csvString.Length - 1, 1);
            
        for (int i = 0; i < 2; i++)
        {
            csvString = csvString.Replace("\"\"", "\"");
        }
        return csvString;
    }
}
