using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeachRoom : Room
{
    public override void Draw()
    {
        if (!state.hasPrincess) DrawCharacter("Peach");
    }
    public override string GetDescription(string cameFromRoom)
    {
        switch (state.hasPrincess)
        {
            case false:  
                return "You found the princess! Looks like this strange guy would let her pass either.";
            case true:
                return "Princess was here but now there is noone here. \n\n You notice a sofa where Princess sat. It looks very comfy and you feel pretty tired.";
            default:
                throw new System.Exception();
        }
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();
        if (state.hasPrincess)
        {
            result.Add(("Take a nap, what can go wrong?",() => {
                state.main.Skyrim(); return "";
            }
            ));
        }
        result.Add(("Return to previous room", () => {
            state.hasPrincess = true;
            return nameof(ShadowTheHedgehogRoom);
        }));
        
        return result;
    }
}
