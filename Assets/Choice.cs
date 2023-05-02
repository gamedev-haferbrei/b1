using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Choice : MonoBehaviour
{
    Main main;
    string label;
    UnityAction action;

    public void Initialize(Main main, int id, string label, UnityAction action)
    {
        this.main = main;
        this.label = label;
        this.action = action;

        GetComponent<TextMeshProUGUI>().text = $"{id}) ${label}";
    }

    public void OnChoiceSelected()
    {
        action();
        main.Redraw();
    }
}
