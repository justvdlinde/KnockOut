using UnityEngine;

public static class Extensions2 {

    public static T GetInterface<T>(this GameObject obj) where T : class {
        if (!typeof(T).IsInterface) {
            Debug.LogError(typeof(T).ToString() + ": is not an interface!");
            return null;
        }
        return obj.GetComponent<T>() as T;
    }

    public static T[] GetInterfaces<T>(this GameObject obj) where T : class {
        if (!typeof(T).IsInterface) {
            Debug.LogError(typeof(T).ToString() + ": is not an interface!");
            return null; ;
        }

        return obj.GetComponents<T>() as T[];
    }

    public static T GetRandom<T>(this T[] arr) {
        return arr[Random.Range(0, arr.Length - 1)];
    }
}
