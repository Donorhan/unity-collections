using UnityEngine;

namespace Do.Collections
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Collections/WeaponDocument")]
    [System.Serializable]
    public class WeaponDocument : Document
    {
        public int damage;
        public int cost;
    }
}
