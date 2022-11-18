using System;
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
    private float _rotationValue;

    private bool _stanceCurrent;
    private bool _movementLock;
    private bool _raiseStanceInput;
    private Attack _attack;
    
    private int _eqiupIndex;
    private int _maxEquipIndex = 1; // <- Hardcoded value!!
    [SerializeField] private float _gravity;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _strafeSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Awake()
    {
        _animator= GetComponentInChildren<Animator>();
        _characterController= GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!_movementLock)
        {
            _animator.SetFloat("DirectionZ", _moveVector.y);
            _animator.SetFloat("DirectionX", _moveVector.x);

            //if (_moveVector.magnitude > 0)
            //{
            //    _animator.SetBool("Walk", true);
            //}
            //else { _animator.SetBool("Walk", false); }

            DetermineWalkAnimation();

            this.transform.Rotate(Vector3.up, _rotationValue * _rotationSpeed);
            _characterController.Move(transform.rotation * new Vector3(_moveVector.x * _strafeSpeed, -_gravity, _moveVector.y * _moveSpeed));
        }
        //else { _animator.SetBool("Walk", false); }

        if (_raiseStanceInput && !_stanceCurrent)
        {
            _animator.SetBool("Stance", true);
        }

        if (!_raiseStanceInput /*&& _stanceCurrent*/)
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

    private void DetermineWalkAnimation()
    {
        if (_moveVector.magnitude == 0)
        {
            _animator.SetBool("Walk", false);
            _animator.SetBool("Strafe", false);
            return;
        }

        float AbsZ = Mathf.Abs(_moveVector.y);
        float AbsX = Mathf.Abs(_moveVector.x);

        if (AbsZ > AbsX)
        {
            _animator.SetBool("Walk", true);
            _animator.SetBool("Strafe", false);
        }
        else
        {
            _animator.SetBool("Walk", false);
            _animator.SetBool("Strafe", true);
        }
    }

    public void SetMoveVector(Vector2 inputVector) { _moveVector = inputVector; }
    public void SetStanceInput(bool input) { _raiseStanceInput = input; }
    public void SetAttackInput(Attack input) { _attack = input; }
    public void MovementLock() { _movementLock = true; }
    public void MovementUnlock() { _movementLock = false; }

    public void SetRotationValue(float input)
    {
        _rotationValue = input;
    }
}
