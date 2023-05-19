using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRoom : Room
{
    //public bool hasApple = false;
    bool firstTime = true;

    State roomState;


    enum State
    {
        TakeApple,
    }


    public override string GetDescription(string cameFromRoom)
    {
        // if if (cameFromRoom != nameof(LinkRoom)) roomState = State.Default;

       

        switch (roomState)
        {
            case State.TakeApple:
                
                return "Well, you did not find your grandchild but at least you got an apple to eat for later or something.";
            default:
                throw new System.Exception();
        }
        if (!firstTime)
        {
            return "Well, this room is empty now :/";

        }
        else
        {
            return "You see an empty storage room, and the only thing you see here is a table with an apple on top.";
            firstTime = false;
        }
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        



        if (!state.hasApple) result.Add(("Take the apple", () => {
            roomState = State.TakeApple;
            state.hasApple = true;
            return nameof(AppleRoom);
        }
            ));

        result.Add(("Return to entrance", () => nameof(Entrance)));

        return result;
    }
    public override void Draw()
    {

    }
    // Start is called before the first frame update
    /*id Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
