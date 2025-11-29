using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TwoLeg : Animal
{
    public override int HasLeg()
    {
        return 2;
    }
}
