using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [SerializeField] float zipSpeed;
    [SerializeField] LayerMask platformLayerMask;

    private Vector3 targetLocation;
    private Rigidbody2D rigidbody2d;


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (targetLocation != null && targetLocation != Vector3.zero)
        {
            Debug.DrawLine(targetLocation, transform.position, Color.green, 1f);
            rigidbody2d.velocity += (Vector2)(targetLocation - transform.position).normalized * zipSpeed * Time.deltaTime;
            Debug.Log(Vector2.Distance(targetLocation, transform.position));
            if (Vector2.Distance(targetLocation, transform.position) < 1f)
            {
                Debug.DrawLine(targetLocation, transform.position, Color.red, 1f);
                SetTargetPosition(Vector3.zero);
            }
        }
    }

    public void AimHarpoon(Vector3 targetLocation)
    {
        Debug.Log("Aim Harpoon");
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, (Utils.GetMouseWorldPosition() - transform.position), 1000f, platformLayerMask);
        Debug.DrawRay(transform.position, (Utils.GetMouseWorldPosition() - transform.position), Color.yellow, 1);
        if (raycastHit.collider != null)
        {
            Debug.Log("RAYCAST HIT POINT" + raycastHit.point);
            SetTargetPosition(raycastHit.point);
        }
    }

    public void CancelHarpoon()
    {
        Debug.Log("Cancel Harpoon");
        SetTargetPosition(Vector3.zero);
    }

    private void SetTargetPosition(Vector3 targetPosition)
    {
        Debug.Log("Setting Target Position: " + targetPosition);
        this.targetLocation = targetPosition;
    }
}