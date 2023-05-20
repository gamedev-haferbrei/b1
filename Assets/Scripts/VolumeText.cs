using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeText : MonoBehaviour
{
    [SerializeField] public Slider slider;
    public TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        buttonText.text = "Volume: " + Mathf.Abs(Mathf.Abs(slider.value*10/8) - 100).ToString("0") + ("%");
    }
}
