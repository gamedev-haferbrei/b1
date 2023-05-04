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
            ("Do this", () => { Debug.Log("foo"); return nameof(Entrance); }),
            ("Do that", () => { Debug.Log("bar"); return nameof(Entrance); }),
        };
    }

    public override string GetDescription()
    {
        return "You are in a museum. Wow.";
    }
}
