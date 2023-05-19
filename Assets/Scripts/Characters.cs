using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    Dictionary<string, Transform> characters = new Dictionary<string, Transform>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t == transform) continue; // For some reason GetComponentsInChildren also returns this (the dummy container's) transform
            characters.Add(t.name, t);
        }
    }

    public void UndrawAll()
    {
        foreach (Transform t in characters.Values)
        {

            t.gameObject.SetActive(false);
        }
    }

    public Transform Get(string name) => characters[name];

    // Update is called once per frame
    void Update()
    {
        
    }
}
