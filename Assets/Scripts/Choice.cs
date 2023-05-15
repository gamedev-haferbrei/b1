using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Choice : MonoBehaviour
{
    Main main;
    string label;
    System.Func<string> action;
   // [SpecializeField] AudioClip mixkitcreakydooropen195;
    //[SerializeField] GameObject audioGO;
   // AudioManager audioManager;
    

    public void Initialize(Main main, int id, string label, System.Func<string> action)
    {
        this.main = main;
        this.label = label;
        this.action = action;

        GetComponent<TextMeshProUGUI>().text = $"{id}) {label}";
    }

    public void OnChoiceSelected()
    {
        
        string room = action();
        //play sound here 
        if (room != "")
        {
            main.SetRoom(room);
        }
        main.Redraw();
    }
}
