using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject fireballImpact;
    //public GameObject fireBlast;
    public int pointsForKilling;
    public int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
    player= FindObjectOfType<PlayerController>();
    if (player.transform.localScale.x<0)
    {
        speed= -speed;
    }
    }

    // Update is called once per frame
    void Update()
    {
       GetComponent<Rigidbody2D>().velocity=new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag== "Enemy"){
            //Instantiate (fireBlast,transform.position,transform.rotation);
            //ScoreManager.AddPoints(pointsForKilling);
            //Destroy (other.gameObject);
            other.GetComponent<EnemyHealthSystem>().GiveDamage(damageToGive);
            Debug.Log("hit enemy");
        }
        Instantiate (fireballImpact,transform.position,transform.rotation);
        Destroy (gameObject);
    }
}



