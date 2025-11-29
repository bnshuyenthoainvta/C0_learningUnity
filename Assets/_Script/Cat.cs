using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat: FourLeg
{
    public override string GetName()
    {
        return "Catty";
    }
    public override string MakeSound()
    {
        return "meo meo";
    }
}
