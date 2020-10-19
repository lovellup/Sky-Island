using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangGlider : MonoBehaviour
{

    [SerializeField] private float gravityScale;
    private Rigidbody2D rigidbody2d;
    private float originalGravityScale;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        originalGravityScale = rigidbody2d.gravityScale;
        Debug.Log(originalGravityScale);
    }

    private void Update() {
        if(Input.GetKey(KeyCode.W)) {
            rigidbody2d.gravityScale = gravityScale;
        } else {
            rigidbody2d.gravityScale = originalGravityScale;
        }
    }
}
