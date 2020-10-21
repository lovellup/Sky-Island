using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    private Rigidbody2D rigidBody2d;
    private Harpoon harpoon;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        harpoon = GetComponent<Harpoon>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            harpoon.AimHarpoon(Utils.GetMouseWorldPosition());
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveRight();
        }
    }

    private void moveLeft()
    {
        rigidBody2d.velocity += Vector2.left * movementSpeed * Time.deltaTime;
        harpoon.CancelHarpoon();
        spriteRenderer.flipX = true;
    }

    private void moveRight() {
        rigidBody2d.velocity += Vector2.right * movementSpeed * Time.deltaTime;
        harpoon.CancelHarpoon();
        spriteRenderer.flipX = false;
    }
}
