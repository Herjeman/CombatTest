using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private bool _stance;
    [SerializeField] private PlayerController _playerController; //no serialize later

    public void Init(PlayerController playerController)
    {
        this._playerController = playerController;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _playerController.SetMoveVector(context.ReadValue<Vector2>());
    }

    public void Stance(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("StanceInput");
            _playerController.SetStanceInput(true);
            _stance = true;
        }
        else if (context.canceled)
        {
            Debug.Log("DropStanceInput");
            _playerController.SetStanceInput(false);
            _stance = false;
        }
    }

    public void AttackUp(InputAction.CallbackContext context)
    {
        if (_stance && context.performed)
        {
            _playerController.SetAttackInput(new Attack(true, "Up"));
        }
    }

    public void AttackDown(InputAction.CallbackContext context)
    {
        Debug.Log("AttackDownInput");
        if (_stance && context.performed)
        {
            _playerController.SetAttackInput(new Attack(true, "Down"));
        }
    }

    public void AttackRight(InputAction.CallbackContext context)
    {
        if (_stance && context.performed)
        {
            _playerController.SetAttackInput(new Attack(true, "Right"));
        }
    }

    public void AttackLeft(InputAction.CallbackContext context)
    {
        if (_stance && context.performed)
        {
            _playerController.SetAttackInput(new Attack(true, "Left"));
        }
    }

    public void ChangeWeapon(InputAction.CallbackContext context) // make sure this is 1 -1 or 0 maybe bumbers?
    {
        if (context.performed)
        {
            _playerController.CycleWeapon((int)context.ReadValue<float>());

        }
    }
}

