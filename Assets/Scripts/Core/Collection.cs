using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Do.Collections
{
    [System.Serializable]
    public class Collection<T> : ScriptableObject, ICollection, IEnumerable<T> where T : Document
    {
        [SerializeField] List<T> elements = null; // Performance: Switch to an HashSet later?

        /**
         * Add an element to the collection.
         *
         * @param element An Element instance
         */
        public void Add(T element)
        {
            elements.Add(element);
        }

        /**
         * Determines whether the collection contains elements that match the given identifier.
         *
         * @param identifier Identifier to test
         * @return True if the identifier exists in the collection
         */
        public bool Exists(string identifier)
        {
            return elements.Exists(i => i.Identifier == identifier);
        }

        /**
         * Remove an element from the collection.
         *
         * @param element An Element instance
         * @return True if the element was in the collection
         */
        public bool Remove(T element)
        {
            return elements.Remove(element);
        }

        /**
         * Find an element using his identifier.
         *
         * @param identifier Element's identifier
         * @return An Element or null if the given identifier wasn't assigned
         */
        public T Find(string identifier)
        {
            return elements.Find(i => i.Identifier == identifier);
        }

        /**
         * Find an element at a given index.
         *
         * @param index Index
         * @return An Element or null if the given index was out of bounds
         */
        public T FindAt(int index)
        {
            if (index < 0 || index >= Count())
                return null;

            return elements[index];
        }

        /**
         * Amount of elements in the collection.
         *
         * @return A positive integer
         */
        public int Count()
        {
            return elements.Count;
        }

        /**
         * Get the collection.
         *
         * @return A collection of Element
         */
        public List<T> GetElements()
        {
            return elements;
        }

        /**
         * Get all identifiers from the collection.
         *
         * @return An array of strings/identifiers
         */
        public string[] GetIdentifiers()
        {
            return Array.ConvertAll(elements.ToArray(), e => e != null ? e.Identifier : "-- Missing identifier --");
        }

        /**
         * Allow iterations on the collection.
         *
         * @return An enumerator
         */
        public IEnumerator<T> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        /**
         * IEnumerable<T> inherits from IEnumerable.
         * Therefore this class must implement both the generic and non-generic versions of GetEnumerator.
         * In most cases, the non-generic method can simply call the generic method.
         */
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
