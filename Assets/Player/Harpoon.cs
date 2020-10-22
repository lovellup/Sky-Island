using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [SerializeField] float zipSpeed;
    [SerializeField] LayerMask platformLayerMask;

    [SerializeField] Transform hookPf;

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
            rigidbody2d.velocity += (Vector2)(targetLocation - transform.position).normalized * zipSpeed * Time.deltaTime;
            if (Vector2.Distance(targetLocation, transform.position) < 1f) 
            {
                SetTargetPosition(Vector3.zero);
            }
        }
    }

    public void AimHarpoon(Vector3 targetLocation)
    {
        Transform hook = Instantiate(hookPf, transform.position, Quaternion.Euler(0,0,Utils.DegreesFromTwoPoints(transform.position, targetLocation)));
        Hook castedHook = hook.GetComponent<Hook>();
        Vector3 targetDirection = (targetLocation - transform.position).normalized;
        Debug.Log(castedHook);
        castedHook.setTargetDirection(targetDirection);
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, (Utils.GetMouseWorldPosition() - transform.position), 1000f, platformLayerMask);
        if (raycastHit.collider != null)
        {
            SetTargetPosition(raycastHit.point);
        }
    }

    public void CancelHarpoon()
    {
        SetTargetPosition(Vector3.zero);
    }

    private void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetLocation = targetPosition;
    }
}