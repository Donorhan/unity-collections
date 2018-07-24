using UnityEngine;

[System.Serializable]
public class CollectionReference<U, T>
where U : Collection<T>
where T : CollectionElement
{
    [IdentifierSelector] [SerializeField] string identifier;
    [SerializeField] public U collection;
    private T reference;

    /**
     * Put in cache the collection's element to avoid find actions on the collection.
     */
    public CollectionReference()
    {
        UpdateCache();
    }

    /**
     * Retrieve the the element from his collection and put it in cache as a reference.
     *
     * @return True if the element is in cache now
     */
    public bool UpdateCache()
    {
        if (collection == null || identifier.Length == 0)
            return false;

        reference = collection.Find(identifier);
        return reference != null;
    }

    public T Value
    {
        get { return reference; }
    }

    public U Collection
    {
        get { return collection; }
    }

    public string Identifier
    {
        get { return identifier; }
        set { identifier = value; }
    }
}
