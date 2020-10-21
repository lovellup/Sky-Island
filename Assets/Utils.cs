using Unity;
using UnityEngine;

class Utils {
    public static Vector3 GetMouseWorldPosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static float DegreesFromTwoPoints(Vector3 pointA, Vector3 pointB) {
        return Mathf.Atan2(pointB.y -pointA.y, pointB.x - pointA.x) *180 /Mathf.PI;
    }
}