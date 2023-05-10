using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] GameObject charactersGO;
    public Characters characters;

    public bool hasClucko = false;

    // Start is called before the first frame update
    void Start()
    {
        characters = charactersGO.GetComponent<Characters>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
