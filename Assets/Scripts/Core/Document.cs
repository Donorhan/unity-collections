using UnityEngine;

namespace Do.Collections
{
    [System.Serializable]
    public abstract class Document : ScriptableObject
    {
        [SerializeField] string identifier = "";
        public string Identifier => identifier;
    }
}