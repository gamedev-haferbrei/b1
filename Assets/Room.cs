using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Room : MonoBehaviour
{
    [SerializeField] protected GameObject stateGO;
    protected GameState state;

    void Start()
    {
        state = stateGO.GetComponent<GameState>();
    }

    public abstract string GetDescription();
    public abstract IEnumerable<(string, System.Func<string>)> GetChoices();
    public abstract void Draw();

    // Called when entering the room from a DIFFERENT room
    public virtual void Enter() {}
}
