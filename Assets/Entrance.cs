using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entrance : Room
{
    public override void Draw()
    {

    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        return new List<(string, System.Func<string>)>
        {
            ("Go to the left", () => nameof(LinkRoom)),
            ("Go to the right", () => nameof(ShadowTheHedgehogRoom)),
        };
    }

    public override string GetDescription()
    {
        return "You are in a museum. Wow.";
    }
}
