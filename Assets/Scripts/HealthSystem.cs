using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    public int health;

    public int TakeDamage(int damage)
    {
        health -= damage;
        return health;
    }

    public int GetHealth() {return health;}

    public void SetHealth(int health) { this.health = health;}

    public void Kill() { health = 0;}
}
