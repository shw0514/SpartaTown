using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f; // 캐릭터의 팔방향이 90도를 넘어가면 무기를 반대방향으로 뒤집음
        characterRenderer.flipX = armRenderer.flipY; // 팔에 든 무기가 반대방향을 향할때 캐릭터도 반대방향을 바라봄
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ); // 팔이 돌아가는 위치
    }
}

