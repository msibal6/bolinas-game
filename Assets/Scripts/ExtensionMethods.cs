using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    // String extension method to test if string is all digits
    public static bool IsAllDigits(this string str) {
        foreach (char c in str) {
            if (c < '0' || c > '9') {
                return false;
            }
        }
        return true;
    }

    public static void PanTo(this Camera camera, Vector3 newPos) {
        Debug.Log("changing camera");
        //camera.transform.position = newPos;
        //Debug.Log("changing camera again");
        Vector3 vector3 = new Vector3(newPos.x, newPos.y, -10f);
        camera.transform.position = vector3;
    }
}
