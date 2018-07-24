using System;

public interface ICollection
{
    /**
     * Get all identifiers from the collection.
     *
     * @return An array of strings/identifiers
     */
    string[] GetIdentifiers();

    /**
     * Determines whether the collection contains elements that match the given identifier.
     *
     * @param identifier Identifier to test
     * @return True if the identifier exists in the collection
     */
    bool Exists(string identifier);

    /**
     * Amount of elements in the collection.
     *
     * @return A positive integer
     */
    int Count();
}
