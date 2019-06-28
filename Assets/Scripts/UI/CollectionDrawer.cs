using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Do.Collections;

public class CollectionDrawer : MonoBehaviour
{
    [SerializeField] WeaponsCollection collection = null;
    [SerializeField] GameObject listElementPrefab = null;
    List<ElementBloc> elements = new List<ElementBloc>();

    void Start()
    {
        ClearElements();
        foreach (Document collectionElement in collection)
        {
            if (collectionElement == null)
                continue;

            GameObject elementObject = GameObject.Instantiate(listElementPrefab);
            elementObject.transform.SetParent(gameObject.transform);

            ElementBloc elementBloc = elementObject.GetComponent<ElementBloc>();
            elementBloc.SetText(collectionElement.Identifier);
            elements.Add(elementBloc);
        }
    }

    void ClearElements()
    {
        foreach (Transform elementTransform in transform)
            GameObject.Destroy(elementTransform.gameObject);
    }
}
