using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventLink : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    public void StanceIsUp() { _playerController.StanceIsUp(); }
    public void StanceIsDown() { _playerController.StanceIsDown(); }
    public void MovementLock() { _playerController.MovementLock(); Debug.Log("AnimationEvent lock"); }
    public void MovementUnlock() { _playerController.MovementUnlock(); }
}
