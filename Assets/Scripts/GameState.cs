using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // These are just here for spaghetti reasons
    [SerializeField] GameObject charactersGO;
    public Characters characters;

    [SerializeField] GameObject mainGO;
    public Main main;

    public bool hasClucko = false;
    public bool hasApple = false;
    public bool hasPassword = false;
    public bool hasPrincess = false;
    public bool isSearchingPeach = false;
    public bool finish = false;

    // Start is called before the first frame update
    void Start()
    {
        characters = charactersGO.GetComponent<Characters>();
        main = mainGO.GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
