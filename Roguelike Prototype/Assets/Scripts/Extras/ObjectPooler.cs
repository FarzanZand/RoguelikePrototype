using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    // Recycles objects instead of recreating them
    // poolSize gives startSize. 
    // These are disabled at start, enabled during use
    // Then disabled again through ReturnToPool script 
    // If objects exceeds start pool-count
    // AddObjectToPool expands it

    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private bool poolCanExpand = true;

    private List<GameObject> pooledObjects;
    private GameObject parentObject;


    // Start is called before the first frame update
    private void Start()
    {
        // Group objects in hierarcy
        parentObject = new GameObject("Pool");
        Refill();
    }

    // Fills the pool to its capacity
    public void Refill()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddObjectToPool();
        }
    }

    // Gets an inactive object from pool if available
    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // If object is not active, return that object. 
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if(poolCanExpand)
        {
            return AddObjectToPool(); 
        }

        return null; 
    }

    // If we want to expand pool with one object, create and deactive it. 
    public GameObject AddObjectToPool()
    {
        GameObject newObject = Instantiate(objectPrefab);
        newObject.SetActive(false);
        newObject.transform.parent = parentObject.transform;

        pooledObjects.Add(newObject);
        return newObject;
    }
}
