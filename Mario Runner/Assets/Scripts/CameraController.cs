using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public bool isFollowing;
    public float xOffset;
    public float yOffset;
    private Vector3 pt;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerController>();
        isFollowing=true;
    }

    // Update is called once per frame
    void Update()
    {
      pt=player.transform.position;
      if (isFollowing)
      transform.position=new Vector3(pt.x + xOffset,pt.y + yOffset,transform.position.z);

    }
}
