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
                return "Princess was here but now there is noone here";
            default:
                throw new System.Exception();
        }
        
        
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        result.Add(("Return to previous room", () => {
            state.hasPrincess = true;
            return nameof(ShadowTheHedgehogRoom);
        }));

        return result;
    }
}
