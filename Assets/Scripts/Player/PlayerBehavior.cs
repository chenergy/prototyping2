using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{
	// Player's health and health bar
	private float curHP		= 100f;
	private float maxHP		= 100f;
	private float maxBAR	= 100f;
	private float curAmmo	= 100f;
	private float maxAmmo	= 100f;
	private float HealthBarLength;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI()
	{
		// Creates the health bar at the coordinates 10,10
		GUI.Box (new Rect (10, 10, HealthBarLength, 25), "");
		// Determines the length of the health bar
		HealthBarLength = curHP * maxBAR / maxHP;
	}

	// Checks if the player has entered a trigger for pickup
	void OnTriggerEnter(Collider other)
	{
		// Checks what tag the other gameobject is, and reacts accordingly.
		switch (other.gameObject.tag) {
		case "HealthPickup": // The gameobject tag: "Heal 25%"
			ChangeHP (25);
			break;
		case "AmmoPickup": // The gameobject tag: "Small Ammo"
			ChangeAmmo (25);
			break;
		default:
			break;
		}
		// Destroys the gameObject the player collided with.
		Destroy (other.gameObject);
	}

	public void ChangeHP(float change)
	{
		Debug.Log ("HP changed. New HP: " + this.curHP);
		this.curHP += change;

		if (this.curHP > this.maxHP) {
			this.curHP = this.maxHP;
		}

		if (this.curHP <= 0) {
			this.curHP = 0;
			Debug.Log ("Player has died!");
		}
	}

	public void ChangeAmmo(float change)
	{
		Debug.Log ("Ammo changed. New Ammo: " + this.curHP);
		this.curAmmo += change;

		if (this.curAmmo > this.maxHP) {
			this.curAmmo = this.maxHP;
		}

		if (this.curAmmo <= 0) {
			this.curAmmo = 0;
			Debug.Log ("Out of Ammo!");
		}
	}
}

