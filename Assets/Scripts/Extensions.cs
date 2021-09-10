using UnityEngine;

public static class Extensions
{
    public static bool HasComponent<T>(this GameObject theObject) where T : Component
    {
        return theObject.GetComponent<T>() != null;
    }
}