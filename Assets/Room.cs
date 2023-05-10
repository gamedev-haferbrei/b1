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

    public void DrawCharacter(string name) => state.characters.Get(name).gameObject.SetActive(true);

    public abstract string GetDescription(string cameFromRoom);
    public abstract IEnumerable<(string, System.Func<string>)> GetChoices();
    public abstract void Draw();
}
