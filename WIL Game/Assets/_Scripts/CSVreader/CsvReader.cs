using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class CsvReader
{
    public static List<string[]> ReadCsv(string fileName)
    {
        TextAsset textAssetData = Resources.Load<TextAsset>(fileName);
        
        List<string[]> result = new List<string[]>();
        string[] row = textAssetData.text.Split("\r\n", System.StringSplitOptions.None);
        foreach (var field in row)
        {
            result.Add(Regex.Split(field, ";"));
        }
        return result;
    }
}
