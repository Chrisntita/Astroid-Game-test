using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private float speed = 500.0f;

    private float maxLifeTime = 10.0f;

    public void project(Vector2 direction)
    {
        rigidbody.AddForce(direction * speed);
        Destroy(gameObject, maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
