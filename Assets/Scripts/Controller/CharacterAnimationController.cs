using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : CharacterAnimations
{

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        animator.SetBool("IsWalking", direction.magnitude > 0f);
    }
}
