using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public bool TestMode = false;
    public int damage;
    public float lifeTime;

    //hidden in inspector because we want to set our speed via script once we instantiate
    [HideInInspector] public float xVel;
    [HideInInspector] public float yVel;

    // Start is called before the first frame update
    void Start()
    {
        if (lifeTime <= 0)
        {
            lifeTime = 2.0f;
            if (TestMode) Debug.Log("Lifetime defaulted to 2 on object " + gameObject.name);
        }

        if (damage <= 0)
        {
            damage = 10;
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerProjectile"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnDestroy()
    {
        //spawn random object based on prefab that you have reference too - or possibly array of references..?
        //gameObject.transform.position;
        //transform.rotation;
    }
}
