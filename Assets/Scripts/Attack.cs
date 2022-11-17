using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Attack
{
    public bool perform;
    public string direction;
    //private static readonly string[] directions = new string[4] {"Up", "Down", "Left", "Right" }; <- sanity check? not necessary...

    public Attack(bool perform, string direction)
    {
        this.perform = perform;
        this.direction = direction;
    }
}
