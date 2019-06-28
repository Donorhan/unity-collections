using UnityEngine;
using UnityEngine.UI;

public class ElementBloc : MonoBehaviour
{
    [SerializeField] Text textComponent = null;

    public void SetText(string text)
    {
        textComponent.text = text;
    }
}
