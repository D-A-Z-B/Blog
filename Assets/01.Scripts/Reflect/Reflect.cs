using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 Velocity;

    private void Start() {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(Random.insideUnitCircle.normalized * 5, ForceMode2D.Impulse);
    }

    private void Update() {
        Velocity = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var speed = Velocity.magnitude;
        var dir = Reflection(Velocity.normalized, other.contacts[0].normal);
        rigid.velocity = dir * Mathf.Max(speed, 0);
    }

    public Vector3 Reflection(Vector3 V, Vector3 N) {
        return V - 2 * (V.x  * N.x + V.y * N.y + V.z + N.z) * N;
    }
}
