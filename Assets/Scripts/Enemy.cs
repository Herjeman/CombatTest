using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UnitBaseClass, IUnarmed, IAxe
{
    public void AxeGetAttacked()
    {
        TakeDamage(5);
    }

    public void UnarmedGetAttacked()
    {
        TakeDamage(1);
    }
}
