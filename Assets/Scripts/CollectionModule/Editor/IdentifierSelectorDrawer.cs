using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomPropertyDrawer(typeof(IdentifierSelector), true)]
public class IdentifierSelectorDrawer : PropertyDrawer
{
    int index = -1;
    ICollection previousCollection;
    string[] identifiers = new string[0];

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Retrieve collection
        SerializedProperty collectionProperty = GetSibling(property, "collection");
        if (collectionProperty == null) return;

        // Get collection's identifiers
        var collectionObject = collectionProperty.objectReferenceValue as ICollection;

        // Put identifiers in cache
        if (collectionObject != null && collectionObject != previousCollection)
        {
            identifiers = collectionObject.GetIdentifiers();
            previousCollection = collectionObject;
        }

        // Find current index
        string currentIdentifier = property.stringValue;
        for (int i = 0; i < identifiers.Length; i++)
        {
            if (identifiers[i] == currentIdentifier)
            {
                index = i;
                break;
            }
        }

        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.BeginChangeCheck();
        index = EditorGUI.Popup(position, label.text, index, identifiers);
        if (EditorGUI.EndChangeCheck() && index != -1 && index < identifiers.Length)
            property.stringValue = identifiers[index];

        EditorGUI.EndProperty();
    }

    SerializedProperty GetSibling(SerializedProperty property, string name)
    {
        // Avoid modifications on the original one
        SerializedProperty copy = property.Copy();

        // Search the next element
        var endProperty = copy.GetEndProperty();
        while (copy.NextVisible(true))
            if (endProperty.name == name)
                return endProperty;

        return null;
    }
}
