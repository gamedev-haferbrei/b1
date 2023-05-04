using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkRoom : Room
{
    bool firstTime = true;
    State roomState = State.Default;

    enum State
    {
        Default,
        ScoldPeter,
        ThrowPot,
    }

    public override void Draw()
    {

    }

    public override void Enter()
    {
        roomState = State.Default;
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        result.Add(("Scold Peter", () => {
            roomState = State.ScoldPeter;
            return nameof(LinkRoom);
        }
        ));

        if (!state.hasClucko) result.Add(("Join in", () => {
            roomState = State.ThrowPot;
            state.hasClucko = true;
            return nameof(LinkRoom);
        }
            ));

        result.Add(("Return to entrance", () => nameof(Entrance)));

        return result;
    }

    public override string GetDescription()
    {
        if (firstTime)
        {
            firstTime = false;
            return "This room is filled with valuable-looking pots. Your childhood hero is here -- it's Peter Pan, unmistakably! He is acting like a maniac, throwing the pots all over the place without regard for human safety. Better get the hell out of here.\n\nThere is a random chicken in the corner.";
        }

        switch (roomState)
        {
            case State.Default:
                return "Actually, on second glance, Tinker Bell has gotten a little... round. You keep it to yourself so as to not upset the raging Peter Pan further.";
            case State.ScoldPeter:
                return "You firmly ask the young man to quit his temper tantrum immediately.\n\nPeter acknowledges your presence with a 'HYUH?', then continues throwing pots. Oh well, he is the boy who won't grow up after all.";
            case State.ThrowPot:
                return "Why not fight fire with fire? You throw a pot directly at Peter's face, to teach the brazen youth a lesson. It shatters into a million pieces, revealing a shiny ruby contained within.\n\nPeter Pan seems pleased. He hands you the chicken.\n\nBetter get the poor bird away from this madman, quickly. You decide to adopt her and provisionally name her Clucko. She is safe with you now.";
            default:
                throw new System.Exception();
        }
    }
}
