using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicator : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text textComponent;

    void Update()
    {
        textComponent.text = player.name + " - " + player.Weapon.Identifier;
    }
}
