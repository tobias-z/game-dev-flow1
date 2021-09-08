using UnityEngine;

public static class Utils
{
    public static bool HasComponent<T>(GameObject theObject) where T : Component
    {
        return theObject.GetComponent<T>() != null;
    }
}