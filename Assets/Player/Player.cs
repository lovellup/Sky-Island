using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    private Rigidbody2D rigidBody2d;
    private Harpoon harpoon;

    private void Awake() {
        rigidBody2d = GetComponent<Rigidbody2D>();
        harpoon = GetComponent<Harpoon>();
    }
    
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement() {
        if (Input.GetMouseButtonDown(0))
        {
            harpoon.AimHarpoon(Utils.GetMouseWorldPosition());
        }
        if(Input.GetKey(KeyCode.A)) {
            rigidBody2d.velocity += Vector2.left * movementSpeed * Time.deltaTime;
            harpoon.CancelHarpoon();
        }
        if(Input.GetKey(KeyCode.D)) {
            rigidBody2d.velocity += Vector2.right * movementSpeed * Time.deltaTime;
            harpoon.CancelHarpoon();
        }
    }
}
