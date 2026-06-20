using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private float deactiveDelay = 2f;
    private Queue<GameObject> pool = new();
    private Queue<GameObject> activeObjetcts = new();
    private void Awake()
    {
        InitializePool();
    }

    public GameObject GetObject()
    {
        if (activeObjetcts.Count > pool.Count * 1.75)
        {
            // If the number of active objects exceeds 1.75 times the pool size, deactivate the oldest active object
            GameObject obj = activeObjetcts.Dequeue();
            ResetObject(obj);

        }
         
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            activeObjetcts.Enqueue(obj);
            //StartCoroutine(DeactiveObject(obj, deactiveDelay));
            return obj;
        }

        return null;

    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = prefab.transform.position; // Reset the object's position to the prefab's position
        obj.transform.rotation = prefab.transform.rotation; // Reset the object's rotation to the prefab's rotation
        pool.Enqueue(obj);

    }

    public void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    private void OnDestroy()
    {
        while (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            Destroy(obj);
        }
    }

    private void ResetObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = prefab.transform.position; // Reset the object's position to the prefab's position
        obj.transform.rotation = prefab.transform.rotation; // Reset the object's rotation to the prefab's rotation
        obj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; // Reset the object's velocity
        pool.Enqueue(obj);
    }

}
