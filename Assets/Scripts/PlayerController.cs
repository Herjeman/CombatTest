using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : UnitBaseClass
{
    private Animator _animator;
    private bool _stance;
    private int _eqiupIndex;
    private int _maxEquipIndex;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_stance)
        {
            _animator.SetTrigger("TakeStance");
        }

        if (Input.GetMouseButtonDown(1) && _stance)
        {
            _animator.SetTrigger("DropStance");
        }

        if (Input.GetMouseButtonDown(0) && _stance)
        {
            _animator.SetTrigger("Down");
        }
    }

    public void StanceIsUp()
    {
        _stance = true;
    }

    public void StanceIsDown()
    {
        _stance = false;
    }

    public void EquipNext()
    {
        _eqiupIndex++;
        if (_eqiupIndex > _maxEquipIndex)
        {
            _eqiupIndex = 0;
        }
        _animator.SetInteger("IdleStanceIndex", _eqiupIndex);
    }
}
