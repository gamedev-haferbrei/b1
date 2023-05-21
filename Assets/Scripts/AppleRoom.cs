using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleRoom : Room
{
    bool firstTime = true;

    State roomState;

    enum State
    {
        HasApple,
        Empty
    }

    public override string GetDescription(string cameFromRoom)
    {
        switch (roomState)
        {
            case State.HasApple:
                return "You see an empty storage room, and the only thing you see here is a table with an apple on top.";
            case State.Empty:
                if (firstTime)
                {
                    firstTime = false;
                    return "Well, you did not find your grandchild but at least you got an apple to eat for later or something.";
                }
                return "Well, this room is empty now :/";
            default:
                throw new System.Exception();
        }
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        if (roomState == State.HasApple) result.Add(("Take the apple", () => {
            roomState = State.Empty;
            state.hasApple = true;
            return nameof(AppleRoom);
        }
            ));

        result.Add(("Return to the painting room", () => nameof(PaintingRoom)));

        return result;
    }
    public override void Draw()
    {

    }
}
