using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig: FourLeg
{
    public override string GetName()
    {
        return "Pinky";
    }
    public override string MakeSound()
    {
        return "é é";
    }

    public override string IsHasFur()
    {
        return "No";
    }
}
