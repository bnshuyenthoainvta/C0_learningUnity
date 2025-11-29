using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    float weight = 2;
    int legs = 4;

    private void Awake()
    {
        this.GetRandomWeight();
    }
    public abstract string GetName();
    public abstract string MakeSound();

    public virtual int HasLeg()
    {
        return this.legs;
    }

    public virtual string IsHasFur()
    {
        return "YES";
    }

    public string GetInFor()
    {
        return "Name: " + this.GetName() + "/Sound: " + this.MakeSound() + "/Leg: " + this.HasLeg() + "/IsHasFur: " + this.IsHasFur() + "/Weight: " + this.GetWeight();
    }

    public virtual float GetWeight()
    {
        return this.weight;
    }
    private void GetRandomWeight()
    {
        this.weight = Random.Range(1f, 30f);
    }
}
