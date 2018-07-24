using UnityEngine;

[System.Serializable]
public class Weapon : CollectionElement
{
    public int damage;
    public int cost;
}

[CreateAssetMenu(fileName = "WeaponsCollection", menuName = "Collections/Weapons")]
public class WeaponsCollection : Collection<Weapon> { }

[System.Serializable]
public class WeaponReference : CollectionReference<WeaponsCollection, Weapon> { }
