using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int pointsToAdd;
    public AudioSource coinSoundEffect;

    void OnTriggerEnter2D(Collider2D other) {
       if(other.GetComponent<PlayerController>()== null)
       return;
       //if anything but the player (like an enemy) reaches the coin,it shouldn't collect it

       ScoreManager.AddPoints(pointsToAdd);
       coinSoundEffect.Play();
       Destroy (gameObject);
    }

}
