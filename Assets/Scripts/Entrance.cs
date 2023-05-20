using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entrance : Room
{
    public override string GetDescription(string cameFromRoom)
    {
        if (state.finish) return "You go out to the main hall and see how your grandchild fools around with the Peter Pan and his strange Tinker Bell. You call him and surprisingly he listens to you. \"He must be pretty hungry if he actually listens to me\" you think, but don't say this aloud. \n\n After lecture about disobeying you both could finally go in to the cafeteria nearby to have a tasty meal. \n\n Happy end!";
        return "You are a friendly grandma who has come to visit the nearby video game museum with your grandchild. However, you fell asleep on a comfy gaming chair and your grandchild is nowhere to be found.\n\nYour trusty watch says it's late evening already. Goodness!\n\nWhat will you do?";
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        if (state.finish) 
        {
            List<(string, Func<string>)> result = new List<(string, Func<string>)>();

            result.Add(returnToMenu);

            return result;
        }
        
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


