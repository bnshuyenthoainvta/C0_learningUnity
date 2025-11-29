using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird: TwoLeg
{
    public override string GetName()
    {
        return "Birdby";
    }
    public override string MakeSound()
    {
        return "chiêm chiếp";
    }
}
