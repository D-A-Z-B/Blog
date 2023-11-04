using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    private Rigidbody2D rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable() {
        StartCoroutine(SelfDes());
        rigid.AddForce(Random.insideUnitCircle.normalized * 5, ForceMode2D.Impulse);
    }

    private IEnumerator SelfDes() {
        yield return new WaitForSeconds(0.2f);
        //Destroy(gameObject);
        ObjectPool.instance.Push(gameObject);
    }
}
