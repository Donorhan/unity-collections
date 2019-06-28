using UnityEngine;
using Do.Collections;

public class Player : MonoBehaviour
{
    public new string name = "Player";
    [SerializeField] WeaponDocument weapon = null;

    public WeaponDocument Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }
}
