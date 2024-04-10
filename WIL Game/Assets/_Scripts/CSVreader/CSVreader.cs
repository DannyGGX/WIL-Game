using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
 
/// <summary>
/// CODE taken from Youtube video: https://youtu.be/tI9NEm02EuE?si=tKBhlBl82kW_2aA1 
/// </summary>
public static class CSVreader
{
    private static TextAsset _textAssetData;
    private static string[] separator = new string[] { ";", "\n" };

    public static int NumberOfColumns { get; private set; }
    public static List<string[]> ReadCsv(string fileName)
    {
        _textAssetData = Resources.Load<TextAsset>(fileName);
        
        List<string[]> result = new List<string[]>();
        string[] row = _textAssetData.text.Split("\r\n", System.StringSplitOptions.None);
        for (int i = 0; i < row.Length; i++)
        {
            result.Add(Regex.Split(row[i], ";"));
        }
        return result;
    }
    
}
