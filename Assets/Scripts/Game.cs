using UnityEngine;
using System.IO;
using Do.Collections;

public class Game : MonoBehaviour
{
    [SerializeField] WeaponsCollection weaponsCollection = null;
    [SerializeField] Player player = null;

    public void Load()
    {
        PlayerModel playerModel = new PlayerModel();
        DataLoader.LoadFromJSON(Path.Combine(Application.dataPath, "Data/Player.json"), playerModel);

        player.name = playerModel.name;
        player.Weapon = weaponsCollection.Find(playerModel.weapon);
    }

    public void Save()
    {
        PlayerModel playerModel = new PlayerModel();
        playerModel.name = player.name;

        if (player.Weapon != null)
            playerModel.weapon = player.Weapon.Identifier;

        DataLoader.SaveToJSON(Path.Combine(Application.dataPath, "Data/Player.json"), playerModel);

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
