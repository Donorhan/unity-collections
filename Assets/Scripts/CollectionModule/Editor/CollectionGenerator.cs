using UnityEngine;
using UnityEditor;
using System.IO;

public class CollectionGenerator : Editor
{
    [MenuItem("Collections/Create collection", false, 0)]
    public static void CreateCollection()
    {
        // Get the save path
        string path = EditorUtility.SaveFilePanelInProject("New collection", "CharactersCollection", "cs", "Hello");
        if (path.Length == 0)
        {
            Debug.LogWarning("No name specified");
            return;
        }

        // Ask the template file to use
        string templateFile = EditorUtility.OpenFilePanel("Template file to use", Path.Combine(Application.dataPath, "Assets"), "txt");
        File.Copy(templateFile, path);

        // Take out all the path junk, and format it.
        string className = System.IO.Path.GetFileNameWithoutExtension(path);
        string classToFile = className.Replace(" ", "").Replace("-", "").Replace("sCollection", "");

        // Replace "[COLLECTION_NAME]" with a real name
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
            lines[i] = lines[i].Replace("[COLLECTION_NAME]", classToFile);

        File.WriteAllLines(path, lines);

        // Refresh Unity's interface
        AssetDatabase.Refresh();
    }
}
