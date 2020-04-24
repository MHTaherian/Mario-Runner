using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PlayerController player;
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    // Start is called before the first frame update
    public int pointPenaltyOnDeath;
    private float defaultGravity;
    private new CameraController camera;
    public HealthSystem healthSystem;
    void Start()
    {
        player= FindObjectOfType<PlayerController>();
        
        camera= FindObjectOfType<CameraController>();

        healthSystem= FindObjectOfType<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer ()
    {
        //move the code to RespawnPlayerCo
        //Instantiate(deathParticle,player.transform.position,player.transform.rotation);
        //Debug.Log("Player Respawn");
        //player.transform.position = currentCheckpoint.transform.position;
        //Instantiate(respawnParticle,currentCheckpoint.transform.position,currentCheckpoint.transform.rotation);
        StartCoroutine ("RespawnPlayerCo");
    }
    public IEnumerator RespawnPlayerCo ()
    {
        Instantiate(deathParticle,player.transform.position,player.transform.rotation);
        player.enabled= false;//stops the player actions
        player.GetComponent<Renderer>().enabled= false;//disappears the player
        camera.isFollowing= false;
        //player.GetComponent<Rigidbody2D>().velocity= Vector2.zero;
        defaultGravity=player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale=0f;
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds (respawnDelay);
        player.GetComponent<Rigidbody2D>().gravityScale=defaultGravity;
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled= true;
        player.GetComponent<Renderer>().enabled= true;
        camera.isFollowing=true;
        healthSystem.FullHealth();
        healthSystem.isDead= false;
        Instantiate(respawnParticle,currentCheckpoint.transform.position,currentCheckpoint.transform.rotation);
    }
}
