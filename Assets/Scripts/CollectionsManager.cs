using UnityEngine;
using System.IO;
using Do.Collections;

public class CollectionsManager : MonoBehaviour
{
    [SerializeField] WeaponsCollection weaponsCollection = null;
    [SerializeField] string collectionsFolder = "Data";

    public void Load()
    {
        DataLoader.LoadFromJSON(GetCompletePath("WeaponsCollection.json"), weaponsCollection);
    }

    public void Save()
    {
        DataLoader.SaveToJSON(GetCompletePath("WeaponsCollection.json"), weaponsCollection);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    string GetCompletePath(string fileName)
    {
        return Path.Combine(Application.dataPath, Path.Combine(collectionsFolder, fileName));
    }
}
