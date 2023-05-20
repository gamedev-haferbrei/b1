using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entrance : Room
{
    public override string GetDescription(string cameFromRoom)
    {
        return "You are a friendly grandma who has come to visit the nearby video game museum with your grandchild. However, you fell asleep on a comfy gaming chair and your grandchild is nowhere to be found.\n\nYour trusty watch says it's late evening already. Goodness!\n\nWhat will you do?";
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        return new List<(string, System.Func<string>)>
        {
            ("Go to the left", () => nameof(MarioRoom)),
            ("Go to the right", () => nameof(ShadowTheHedgehogRoom)),
            ("Go straight ahead", () => nameof(PaintingRoom)),
        };
    }

    public override void Draw()
    {

    }
}


