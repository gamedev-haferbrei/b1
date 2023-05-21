using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordRoom : Room
{
    public override string GetDescription(string cameFromRoom)
    {
        return "Hurray! There he is! Your little boy! You could not be happier that you finally found him in this terrible institution.";
    }    

   public override IEnumerable<(string, Func<string>)> GetChoices()
    {
        List<(string, Func<string>)> result = new List<(string, Func<string>)>();

        result.Add(returnToMenu);

        return result;
    }
    public override void Draw()
    {

    }
}
