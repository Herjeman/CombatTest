using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : UnitBaseClass
{
    private Animator _animator;
    private CharacterController _characterController;
    private Vector2 _moveVector;

    private bool _stanceCurrent;

    private bool _raiseStanceInput;
    //private bool _dropStanceInput;
    private Attack _attack;
    
    private int _eqiupIndex;
    private int _maxEquipIndex = 1; // <- Hardcoded value!!

    private void Awake()
    {
        _animator= GetComponentInChildren<Animator>();
        _characterController= GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!_stanceCurrent)
        {
            _characterController.Move(_moveVector); // no gravity atm
        }

        if (_raiseStanceInput && !_stanceCurrent)
        {
            _animator.SetBool("Stance", true);
        }

        if (!_raiseStanceInput && _stanceCurrent)
        {
            Debug.Log("Drop stance");
            _animator.SetBool("Stance", false);
        }

        if (_attack.perform && _stanceCurrent)
        {
            _animator.SetTrigger(_attack.direction);
            _attack.perform = false;
        }
    }

    public void StanceIsUp()
    {
        _stanceCurrent = true;
    }

    public void StanceIsDown()
    {
        _stanceCurrent = false;
    }

    public void CycleWeapon(int cycleDirection)
    {
        _eqiupIndex += cycleDirection;
        if (_eqiupIndex > _maxEquipIndex)
        {
            _eqiupIndex = 0;
        }
        else if (_eqiupIndex < 0)
        {
            _eqiupIndex = _maxEquipIndex;
        }
        _animator.SetInteger("IdleStanceIndex", _eqiupIndex);
        Debug.Log(_eqiupIndex);
    }


    public void SetMoveVector(Vector2 inputVector) { _moveVector = inputVector; }
    public void SetStanceInput(bool input) { _raiseStanceInput = input; }
    public void SetAttackInput(Attack input) { _attack = input; }
}
