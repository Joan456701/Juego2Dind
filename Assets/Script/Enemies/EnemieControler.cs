using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public Rigidbody2D cRigidbody;
    public Transform[] waypoints;

    public float speed = 1f;
    public float damageForce = 5f; 

    private int currentPoint = 0;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = waypoints[currentPoint].position - transform.position;
        dir.y = 0;

        cRigidbody.velocity = new Vector2(dir.normalized.x * speed, cRigidbody.velocity.y);

        // Bucle de la patrol
        if (dir.magnitude < 0.1f)
        {
            currentPoint = (currentPoint + 1) % waypoints.Length;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();

        if (hCtr != null)
        {
            hCtr.Damage();

            Rigidbody2D cRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            cRigidbody.AddForce(Vector2.up * damageForce, ForceMode2D.Impulse);
        }
    }
}