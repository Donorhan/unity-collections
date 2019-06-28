using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicator : MonoBehaviour
{
    [SerializeField] Player player = null;
    [SerializeField] Text textComponent = null;

    void Update()
    {
        string weaponName = player.Weapon ? player.Weapon.Identifier : "Unknown";
        textComponent.text = player.name + " - " + weaponName;
    }
}
