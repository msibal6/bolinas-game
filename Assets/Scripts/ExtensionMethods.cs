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
}
