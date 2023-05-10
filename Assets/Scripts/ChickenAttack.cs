using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAttack : Room
{
    public override string GetDescription(string cameFromRoom)
    {
        return "You shouldn't have done that.";
    }

    public override void Draw()
    {
    
    }

    public override IEnumerable<(string, Func<string>)> GetChoices()
    {
        List<(string, Func<string>)> result = new List<(string, Func<string>)>();

        result.Add(returnToMenu);

        return result;
    }
}
