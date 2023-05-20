using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioRoom : Room
{
 /*   State roomState = State.Default;
    enum State
    {
        Default
    }*/
    public override void Draw()
    {
        DrawCharacter("Mario");
    }
    public override string GetDescription(string cameFromRoom)
    {
        return "Mario Room";
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();
        
        result.Add(("Go ahead", () => nameof(LinkRoom)));
        result.Add(("Return to the entrance", () => nameof(Entrance)));

        return result;
    }
}
