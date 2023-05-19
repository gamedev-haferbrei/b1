using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingRoom : Room
{
    bool firstTime = true;
    //bool hasPassword = false;

    State roomState;

    

    enum State
    {
        AskHints,
        NoPassword,
    }

    public override string GetDescription(string cameFromRoom)
    {
        // if if (cameFromRoom != nameof(LinkRoom)) roomState = State.Default;

        if (firstTime)
        {
            firstTime = false;
            return "Suddenly you are in a room full of paintings. But look! They are moving! 'Are you looking for the brat that just came by here?', an ancient soldier from a painting speaks.";

        }
        switch (roomState)
        {
            case State.AskHints:
                return "'Hmm well, well. I did see the brat run past me down the hall to the left. However, he was not alone, he had some hyperactive child dressed in green with him. To be honest, he seems like a hungry, annoying guy. Good luck with him.";
            case State.NoPassword:
                return "''Insert Password', well... I guess i have to find the password after all...";
            default:
                throw new System.Exception();
        }
    }

    public override IEnumerable<(string, System.Func<string>)> GetChoices()
    {
        var result = new List<(string, System.Func<string>)>();

        result.Add(("Ask For Hints", () => {
            roomState = State.AskHints;
            return nameof(PaintingRoom);
        }
        ));


        result.Add(("Go to the left door", () => {
            return nameof(AppleRoom);
        }
        ));

        result.Add(("Go down the hall", () => {
            if (state.hasPassword)
            {
                return nameof(PasswordRoom);
            }
            else
            {
                roomState = State.NoPassword;
                return nameof(PaintingRoom);
            }

        }
        ));

        result.Add(("Return to entrance", () => nameof(Entrance)));

        return result;
    }


    public override void Draw()
    {
    }













    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
