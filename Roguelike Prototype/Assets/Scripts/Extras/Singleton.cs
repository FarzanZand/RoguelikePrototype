using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    // If you want to get access to a script from wherever without using getcomponent, you can use this.
    // For global access, change parent from monobehaviour to Singleton<ScriptName>. 
    // You can now access the script from any code with ScriptName.Instance.MethodName(); 

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject newGameObject = new GameObject();
                    instance = newGameObject.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        {
            instance = this as T;
        }
    }
}
