using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int enemyHealth;
    public int pointsOnDeath;
    public GameObject deathParticle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth<=0){
            ScoreManager.AddPoints(pointsOnDeath);
            Instantiate(deathParticle,gameObject.transform.position,gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
    public void GiveDamage (int damageToGive)
    {
        enemyHealth-= damageToGive;
        GetComponent<AudioSource>().Play();
    }
}
