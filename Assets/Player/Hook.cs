using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] float speedMultiplier = 80.0f;

    public void setTargetDirection(Vector3 targetDirection)
    {
        Debug.Log("Set Target Direction: " + targetDirection);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(targetDirection.x, targetDirection.y) * speedMultiplier, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Player>() == null) {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
