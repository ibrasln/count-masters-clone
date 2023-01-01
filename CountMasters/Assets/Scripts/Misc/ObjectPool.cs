using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    [Serializable]
    public struct Pool
    {
        public string objectName;
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public Transform parentObject;
        public int poolSize;
    }

    [SerializeField] private Pool[] pools;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].pooledObjects = new();

            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject go = Instantiate(pools[i].objectPrefab, pools[i].parentObject.position, Quaternion.identity, pools[i].parentObject);

                float randomPositionRange = 2f;
                go.transform.position = new Vector3(UnityEngine.Random.Range(pools[i].parentObject.position.x - randomPositionRange, pools[i].parentObject.position.x + randomPositionRange),
                                                       pools[i].parentObject.position.y,
                                                       UnityEngine.Random.Range(pools[i].parentObject.position.z - randomPositionRange, pools[i].parentObject.position.z + randomPositionRange));

                go.name = pools[i].objectName + "_" + (j + 1);
                
                go.SetActive(false);

                pools[i].pooledObjects.Enqueue(go);
            }
        }
    }

    public void GetPooledObject(int objectNumber, int objectAmount)
    {
        if (objectNumber >= pools.Length) return;

        for (int i = 0; i < objectAmount; i++)
        {
            GameObject go = pools[objectNumber].pooledObjects.Dequeue();

            go.SetActive(true);

            pools[objectNumber].pooledObjects.Enqueue(go);
        }
    }

}
