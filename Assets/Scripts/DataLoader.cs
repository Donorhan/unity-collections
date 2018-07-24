using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataLoader
{
    public static void LoadFromJSON(string path, object target)
    {
        string json = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(json, target);
    }

    public static void SaveToJSON(string path, object target)
    {
        string json = JsonUtility.ToJson(target);
        File.WriteAllText(path, json);
    }
}
