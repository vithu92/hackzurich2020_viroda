using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SmartRecommenderSystem
{
    var rules = new str[,];
    SmartRecommenderSystem()
    {
        var path: String = "Assets/DataModels/rules.csv";
        var fileData : String  = System.IO.File.ReadAllText(path);
        var lines : String[] = fileData.Split("\n"[0]);
        int index = 0;
        foreach (var line in lines) {
            var lineData : String[] = (lines[0].Trim()).Split(","[0]);
            rules[0][index] = lineData[1].Substring(1, lineData[1].Length - 2);
            rules[1][index] = lineData[2].Substring(1, lineData[2].Length - 2);
            index++;
        }
    }

    GetRecommendation(var str) {
        var index = Array.IndexOf(rules[0], str);
        return rules[1][index];
    }
}