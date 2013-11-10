using UnityEngine;
using System.Collections;

public class Health_Bar_Pickup : MonoBehaviour {

	// Player's health and health bar
	public float curHP=100;
	public float maxHP=100;
	public float maxBAR=100;
	public float HealthBarLength;

	void OnGUI()
	{
		// Creates the health bar at the coordinates 10,10
		GUI.Box(new Rect(10,10,HealthBarLength,25), "");
		// Determines the length of the health bar
		HealthBarLength=curHP*maxBAR/maxHP;
	}	

	void ChangeHP(float Change)
	{
		// Takes whatever value is passed to this function and add it to curHP.
		curHP+=Change;
		
		// Don't go over the max health
		if(curHP>maxHP)
		{
			curHP=100;
		}
		
		// Ccheck if the player has died
		if(curHP<=0)
		{
			// Die
			Debug.Log("Player has died!");
		}
	}
	
	
	// Checks if the player has entered a trigger for pickup
	void OnTriggerEnter(Collider other)
	{
		// Checks what tag the other gameobject is, and reacts accordingly.
		switch(other.gameObject.tag)
		{
		case "Ammo":
			break;
		default:
			break;
		}
		// Destroys the gameObject the player collided with.
		Destroy(other.gameObject);
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
