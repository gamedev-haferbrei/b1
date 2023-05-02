using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Room : MonoBehaviour
{
    [SerializeField] GameObject stateGO;
    GameState state;

    void Start()
    {
        state = stateGO.GetComponent<GameState>();
    }

    public abstract string GetDescription();
    public abstract IEnumerable<(string, UnityAction)> GetChoices();
    public abstract void Draw();
}
