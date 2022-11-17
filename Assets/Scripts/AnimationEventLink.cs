using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventLink : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    public void StanceIsUp() { _playerController.StanceIsUp(); }

    public void StanceIsDown() { _playerController.StanceIsDown(); }
}
