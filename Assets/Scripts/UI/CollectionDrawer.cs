using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionDrawer : MonoBehaviour
{
    [SerializeField] WeaponsCollection collection;
    [SerializeField] GameObject listElementPrefab;
    List<ElementBloc> elements = new List<ElementBloc>();

    void Start()
    {
        ClearElements();
        foreach (CollectionElement collectionElement in collection)
        {
            GameObject elementObject = GameObject.Instantiate(listElementPrefab);
            elementObject.transform.SetParent(gameObject.transform);

            ElementBloc elementBloc = elementObject.GetComponent<ElementBloc>();
            elementBloc.SetText(collectionElement.name);
            elements.Add(elementBloc);
        }
    }

    void ClearElements()
    {
        foreach (Transform elementTransform in transform)
            GameObject.Destroy(elementTransform.gameObject);
    }
}
