using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour
{
    public float bounceOnEnemy;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=transform.parent.GetComponent<Rigidbody2D>();//gets the component RigidBody2D from its parent
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag== "Enemy"){
            Destroy (other.gameObject);
            rb.velocity= new Vector2(rb.velocity.x,bounceOnEnemy);
        }
    }
}
