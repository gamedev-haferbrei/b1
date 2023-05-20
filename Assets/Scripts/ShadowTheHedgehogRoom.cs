using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTheHedgehogRoom : Room
{
    bool firstTime = true;
    bool hasSeenClucko = false;

    public override IEnumerable<(string, Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        result.Add(("Return to entrance", () => nameof(Entrance)));

        if (hasSeenClucko) result.Add(("Proceed", () => nameof(PeachRoom)));   // rn missing the frame after "proceed" (which is in line 26-27)

        return result;
    }

    public override string GetDescription(string cameFromRoom)
    {
        if (hasSeenClucko)
        {
            return "You keep thinking about the strange way the grim figure has complimented your companion. You are pretty confident Clucko is a female chicken, and you are very sure you do not qualify as a 'brother'." +
                "\n\nYou attribute it to this current gender craze that's all the rave with the new generation. He seems to have been well-intentioned, so you decide not to dwell on it too much.";
        }
        else if (state.hasClucko)
        {
            hasSeenClucko = true;
            if (firstTime)
            {
                firstTime = false;
                return "There is a grim-looking youth with spiky hair in this room. His entire body is covered in black artificial-looking hair. This must be one of these vile 'furries' people on the television warned you about!" +
                    "\n\nSuddenly, he looks at Clucko and remarks 'nice cock bro.' in a tone of comeradery. You aren't sure what that means, but it looks like he will let you pass.";
            } else
            {
                return "Suddenly, the spiky gent looks at Clucko and remarks 'nice cock bro.' in a tone of comeradery. You aren't sure what that means, but it looks like he will let you pass.";
            }
        } else
        {
            if (firstTime)
            {
                firstTime = false;
                return "There is a grim-looking youth with spiky hair in this room. His entire body is covered in black artificial-looking hair. This must be one of these vile 'furries' people on the television warned you about!" +
                     "\n\nYou increasingly regret trusting this establishment with your grandchild. The young man senses your distrust. Seems like he won't let you pass.";
            } else
            {
                return "Ah, not that filthy creature again. You bet he also incentivizes drug use in minors, and he dresses like one of those depressed emo punk hippies. You will not tolerate these people around your grandchild!" +
                    "\n\n... Yeah, still no hope of passing with that kind of attitude.";
            }
        }
    }

    public override void Draw()
    {
        if (hasSeenClucko)
        {
            DrawCharacter("Shadow Nice Cock");
            DrawCharacter("Cucco");
        }
        else
        {
            DrawCharacter("Shadow");
        }
    }
}
