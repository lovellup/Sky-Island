using Unity;
using UnityEngine;

class Utils {
    public static Vector3 GetMouseWorldPosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}