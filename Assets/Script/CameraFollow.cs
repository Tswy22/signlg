using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player; //ตัวออพเจคที่กล้องจะตาม
    public float xMin;//0
    public float xMax;//18.68
    public float yMin;
    public float yMax;

	void Start()
    {
        // If player isn't assigned, try to find it by tag
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // If we found the player, update the camera's position
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            Debug.LogError("Player not found! Make sure your player has the 'Player' tag.");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            float x = Mathf.Clamp(player.transform.position.x,xMin,xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x,y,gameObject.transform.position.z);
        }
    }
}
