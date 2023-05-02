using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Room : MonoBehaviour
{
    [SerializeField] GameObject stateGO;
    GameState gameState;

    void Start()
    {
        gameState = stateGO.GetComponent<GameState>();
    }

    public abstract string GetDescription();
    public abstract IEnumerator<(string, UnityAction)> GetChoices();
    public abstract void Draw();
}
