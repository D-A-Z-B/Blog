using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject objectPrefab;
    public Transform parent;
    public int initCount;
    private Queue<GameObject> pools = new Queue<GameObject>();

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        } else {
            Destroy(gameObject);
        }
    }

    public void Init() {
        for (int i = 0; i < initCount; i++) {
            Push(CreateObject());
        }
    }

    public GameObject CreateObject() {
        return Instantiate(objectPrefab);
    }

    public GameObject Pop() {
        print(pools.Count);
        if (pools.Count > 0) {
            GameObject obj = pools.Dequeue();
            obj.transform.parent = null;
            obj.SetActive(true);
            return obj;
        } else {
            GameObject obj = CreateObject();
            obj.SetActive(true);
            return obj;
        }
    }

    public void Push(GameObject obj) {
        obj.transform.position = Vector2.zero;
        obj.transform.parent = parent;
        obj.SetActive(false);
        pools.Enqueue(obj);
    }
}
