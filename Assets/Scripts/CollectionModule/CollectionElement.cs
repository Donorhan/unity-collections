using UnityEngine;

[System.Serializable]
public abstract class CollectionElement
{
    public string identifier;
    public string name;

    public string Identifier
    {
        get { return identifier; }
    }
}
