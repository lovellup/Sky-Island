using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Camera mainCamera;

    void Update()
    {
        mainCamera.transform.SetPositionAndRotation(new Vector3(
            transform.position.x,
            transform.position.y,
            mainCamera.transform.position.z
        ),
        Quaternion.identity);
    }
}
