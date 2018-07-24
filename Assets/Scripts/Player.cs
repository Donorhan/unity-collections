using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public new string name = "Player";
    [SerializeField] WeaponReference weapon;

    public void Load()
    {
        DataLoader.LoadFromJSON(Path.Combine(Application.dataPath, "Data/Player.json"), this);
    }

    public void Save()
    {
        DataLoader.SaveToJSON(Path.Combine(Application.dataPath, "Data/Player.json"), this);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    public WeaponReference Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }
}
