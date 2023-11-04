using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private void Start() {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects() {
        while (true) {
            GameObject obj = ObjectPool.instance.Pop();
            //Instantiate(ObjectPool.instance.objectPrefab);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
