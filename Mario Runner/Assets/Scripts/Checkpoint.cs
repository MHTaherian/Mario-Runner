using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
       levelManager = FindObjectOfType<LevelManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.name == "Player")
      {
          levelManager.currentCheckpoint= gameObject;
          //when the player enters the second checkpoint trigger,currentCheckpoint changes
          Debug.Log("Activated Checkpoint" + transform.position);
      }  
}
}
