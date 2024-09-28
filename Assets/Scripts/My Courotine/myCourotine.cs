using System.Collections;
using UnityEngine;

public static class myCourotine
{
    public static IEnumerator WaitForRealSeconds(float time) 
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < (start + time))
            yield return null;
    }
}
