using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

	public static int playerHealth;

	public int maxPlayerHealth;
	public Text text;
	public bool isDead;

	private LevelManager levelManager;
	//private LifeManager lifeSystem;
	//private TimeManager theTime;

	// Use this for initialization
	void Start ()
	{
		this.text = GetComponent<Text> ();
		playerHealth= maxPlayerHealth;
		//HealthSystem.playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");
		levelManager = FindObjectOfType<LevelManager> ();
		isDead = false;
		//this.lifeSystem = FindObjectOfType<LifeManager> ();
		//this.theTime = FindObjectOfType<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerHealth<=0 && !isDead) {
			playerHealth= 0;
			levelManager.RespawnPlayer();
			isDead= true;
		}

		text.text = "" + playerHealth;
	}

	public static void HurtPlayer (int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void FullHealth ()
	{
		playerHealth= maxPlayerHealth;
	}

	//public void KillPlayer ()
	//{
	    //playerHealth = 0;

	//}
}
