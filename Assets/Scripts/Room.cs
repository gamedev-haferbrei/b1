using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Room : MonoBehaviour
{
    
    [SerializeField] protected GameObject stateGO;
    protected GameState state;

    public Sprite background;
    protected (string, System.Func<string>) returnToMenu;

    void Start()
    {
        state = stateGO.GetComponent<GameState>();

        returnToMenu = ("Return to menu", () => { state.main.ReturnToMenu(); return ""; });
    }

    public void DrawCharacter(string name) => state.characters.Get(name).gameObject.SetActive(true);

    public abstract string GetDescription(string cameFromRoom);
    public abstract void Draw();
    public abstract IEnumerable<(string, System.Func<string>)> GetChoices();
    //public abstract void PlaySound();
}
