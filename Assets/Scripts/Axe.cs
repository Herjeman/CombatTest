using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon 
// maybe just fuck all and extract a base class from this later instead
{
    private Collider _hitbox;

    private void Awake()
    {
        _hitbox = GetComponent<Collider>();
    }

    public override void Attack() // Call from animator?
    {
        _hitbox.enabled = true;
    }

    public /*override*/ void CancelAttack() // Call from animator?
    {
        _hitbox.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Do axe-stuff to other
        other.GetComponent<Enemy>().AxeGetAttacked();
        // maybe this is only place weapons need to differ?
        Debug.Log($"Axe hit: {other.name} at {other.transform.position}");
    }
}
