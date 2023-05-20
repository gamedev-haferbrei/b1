using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioRoom : Room
{
    State roomState = State.First;
    enum State
    {
        First,
        Ask,
        Help,
        Found,
    }
    public override void Draw()
    {
        DrawCharacter("Mario");
        if (state.hasPrincess) DrawCharacter("Peach");
    }
    public override string GetDescription(string cameFromRoom)
    {
        if (state.hasPrincess)
        {
            roomState = State.Found;
        }
        switch (roomState)
        {
            case State.First:
                return "You see a man with great moustache. His overalls make you think he is some kind of maintenance worker. \"It's-a me, Mario!\" he says. What a nice man, he introduced himself immediately. \nBut still nothing special to see here.";
            case State.Ask:
                return "You are asking the worker about your missing grandson.\n \"Have you seen the Princess? PRINCESS! Hmm, I'm can't find her.\" he exclaimed, but no further response. What a weirdo, these people nowadays are certainly going crazy. What princess, does he think he is some kind of a prince? \n\n But maybe if I will find the princess he will help me.";
            case State.Help:
                return "He keeps talking about his princess and nothing seems to interest him more. \n\n I won't get any help here until i bring him his princess back.";
            case State.Found:
                state.finish = true;
                return "\"Mamma mia! Thank you-a so much!\" says Mario, but suddenly you hear the familiar laughs from the entrance side, need to go check what is happening there";
            default:
                throw new System.Exception();
        }
        
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        if (roomState != State.Found)
        {
            result.Add((("Go ahead in the next room"), () =>
            {
                if (roomState == State.First)
                {
                    roomState = State.First;
                }
                else
                {
                    roomState = State.Help;
                }
                return nameof(LinkRoom);
            }
            ));
            result.Add((("Ask about your grandson"), () =>
            {
                if (roomState == State.First)
                {
                    state.isSearchingPeach = true;
                    roomState = State.Ask;
                    return nameof(MarioRoom);
                }
                else
                {
                    roomState = State.Help;
                    return nameof(MarioRoom);
                }
            }
            ));
        }
        result.Add((("Go back to the entrance"), () =>
        {
            if (roomState == State.First)
            {
                roomState = State.First;
            }
            else
            {
                roomState = State.Help;
            }
            return nameof(Entrance);
        }
        ));


        return result;
    }
}
