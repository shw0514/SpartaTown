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

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f; // ĳ������ �ȹ����� 90���� �Ѿ�� ���⸦ �ݴ�������� ������
        characterRenderer.flipX = armRenderer.flipY; // �ȿ� �� ���Ⱑ �ݴ������ ���Ҷ� ĳ���͵� �ݴ������ �ٶ�
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ); // ���� ���ư��� ��ġ
    }
}

