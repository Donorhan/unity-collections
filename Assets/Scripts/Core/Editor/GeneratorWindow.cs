using UnityEngine;
using UnityEditor;
using System.IO;
namespace Do.Collections
{
    public class CollectionEditor : EditorWindow
    {
        string collectionName = "";
        static string outputPath = "";

        [MenuItem("Collections/New collection ", false, 100)]
        static void Init()
        {
            outputPath = Application.dataPath + "/Data/";

            CollectionEditor window = EditorWindow.GetWindow<CollectionEditor>();
            window.minSize = new Vector2(500, 250);
            window.ShowTab();
        }

        void OnGUI()
        {
            GUILayout.Space(10);
            EditorGUILayout.LabelField("Add a new collection.", EditorStyles.wordWrappedLabel);
            GUILayout.Space(10);
            collectionName = EditorGUILayout.TextField("Collection's name", collectionName);
            GUILayout.Space(60);
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Create"))
            {
                string upperName = char.ToUpper(collectionName[0]) + collectionName.Substring(1);
                CreateDatabaseFile(upperName);
                CreateDocumentFile(upperName);
                AssetDatabase.Refresh();

                Close();
            }

            if (GUILayout.Button("Cancel"))
                Close();

            EditorGUILayout.EndHorizontal();
        }

        void CreateDatabaseFile(string collectionName)
        {
            string ouput = outputPath + collectionName + "Collection.cs";

            // Ask the template file to use
            string templateFile = EditorUtility.OpenFilePanel("Template file to use", Path.Combine(Application.dataPath, "Assets"), "txt");
            File.Copy(templateFile, ouput);

            // Replace "[COLLECTION_NAME]" with a real name
            string[] lines = File.ReadAllLines(ouput);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Replace("[COLLECTION_NAME]", collectionName);

            File.WriteAllLines(ouput, lines);
        }

        void CreateDocumentFile(string collectionName)
        {
            string ouput = outputPath + collectionName + "Document.cs";

            // Ask the template file to use
            string templateFile = EditorUtility.OpenFilePanel("Template file to use", Path.Combine(Application.dataPath, "Assets"), "txt");
            File.Copy(templateFile, ouput);

            // Replace "[COLLECTION_NAME]" with a real name
            string[] lines = File.ReadAllLines(ouput);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = lines[i].Replace("[COLLECTION_NAME]", collectionName);

            File.WriteAllLines(ouput, lines);
        }
    }
}
