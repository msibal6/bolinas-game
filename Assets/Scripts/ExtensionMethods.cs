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
        //Vector3 vector3 = new Vector3(newPos.x, newPos.y, -10f);
        camera.transform.position = new Vector3(newPos.x, newPos.y, -10f);
    }

    public static void RotateTo(this GameObject gameObject, Vector3 oldPos, Vector3 newPos) {
        float x1 = oldPos.x;
        float y1 = oldPos.y;
        float x2 = newPos.x;
        float y2 = newPos.y;

        float xp = x2 - x1;
        float yp = y2 - y1;

        float localAngle = Mathf.Acos(xp / Mathf.Sqrt(xp * xp + yp * yp));
        localAngle = localAngle * 180 / Mathf.PI;
        if (xp <= 0 && yp <= 0) {
            localAngle = 270 -  localAngle;
        } else if (xp > 0 && yp <= 0) {
            localAngle = -localAngle - 90;

        } else if (xp > 0 && yp > 0) {
            localAngle -= 90;
        } else if (xp <= 0 && yp > 0) {
            localAngle = 90 + localAngle - 180;
        }
        //Debug.Log(localAngle);
        gameObject.transform.eulerAngles = new Vector3(0, 0, localAngle);
    }
}
