using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entrance : Room
{
    public override void Draw()
    {

    }

    public override IEnumerable<(string, UnityAction)> GetChoices()
    {
        return new List<(string, UnityAction)>
        {
            ("Do this", () => { Debug.Log("foo"); }),
            ("Do that", () => { Debug.Log("bar"); }),
        };
    }

    public override string GetDescription()
    {
        return "You are in a museum. Wow.";
    }
}
