using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBaseClass : MonoBehaviour
{
    HealthSystem _healthSystem;
    Weapon _equippedWeapon;

    public void TakeDamage(int damage)
    {
        if (_healthSystem.TakeDamage(damage) <= 0)
        {
            Die();
        }
    }

    private void EquipWeapon(Weapon newWeapon)
    {
        _equippedWeapon = newWeapon;
    }

    public void Die()
    {
        Debug.Log("Died");
    }

    private void Stagger()
    {
        Debug.Log("Staggered");
    }



}
