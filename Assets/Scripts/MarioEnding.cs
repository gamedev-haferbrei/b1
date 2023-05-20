using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioEnding : Room
{
    public override string GetDescription(string cameFromRoom)
    {
        return "You go out to the main hall and see how your grandchild fools around with the Peter Pan and his strange Tinker Bell. You call him and surprisingly he listens to you. \"He must be pretty hungry if he actually listens to me\" you think, but don't say this aloud. \n\n After lecture about disobeying you both could finally go in to the cafeteria nearby to have a tasty meal.";
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        List<(string, Func<string>)> result = new List<(string, Func<string>)>();

        result.Add(returnToMenu);

        return result;
    }

    public override void Draw()
    {

    }
}
