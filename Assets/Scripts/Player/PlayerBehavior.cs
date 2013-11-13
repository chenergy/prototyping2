using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WeaponType{ MAIN, ROCKET };
public enum AllyType{ MECHA, ORB };

public class PlayerBehavior : MonoBehaviour
{
	// Player's health and health bar
	private float curHP		= 100f;
	private float maxHP		= 100f;
	private float maxBAR	= 100f;
	private float HealthBarLength;
	
	private int[] allies;
	private int[] curClipAmmo;
	private int[] maxClipAmmo;
	private int[] curTotalWeaponAmmo;
	private int[] maxTotalWeaponAmmo;
	private bool[] activatedWeapons;
	
	// Use this for initialization
	void Start ()
	{
		this.allies 			= new int[] { 0, 0 }; // 0 = MECHA, 1 = ORB
		this.curClipAmmo 		= new int[] { 16, 0 }; // 0 = MAIN, 1 = ROCKET
		this.maxClipAmmo 		= new int[] { 16, 4 };
		this.curTotalWeaponAmmo = new int[] { 64, 0 }; 
		this.maxTotalWeaponAmmo = new int[] { 64, 16 };
		this.activatedWeapons	= new bool[] { true, false };
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
	
	void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag) {
		case "HealthPickup":
			ChangeHP (50);
			GameObject.Destroy (other.gameObject);
			break;
		case "AmmoPickup":
			ChangeAmmo (25);
			GameObject.Destroy (other.gameObject);
			break;
		default:
			break;
		}
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
		this.RechargeAmmo ();
		/*
		Debug.Log ("Ammo changed. New Ammo: " + this.curHP);
		this.curAmmo += change;

		if (this.curAmmo > this.maxHP) {
			this.curAmmo = this.maxHP;
		}

		if (this.curAmmo <= 0) {
			this.curAmmo = 0;
			Debug.Log ("Out of Ammo!");
		}
		*/
	}

	/*
	 * this.allies contains an array of the number of allies
	 * that the player can spawn at a location.
	 * [0] = Mecha
	 * [1] = Orb
	 */
	public void AddAllyEnemy(AllyType ally){
		switch (ally) {
		case AllyType.MECHA:
			break;
		case AllyType.ORB:
			break;
		default:
			break;
		}
	}

	public void SummonAlly(AllyType ally){
		switch (ally) {
		case AllyType.MECHA:
			break;
		case AllyType.ORB:
			break;
		default:
			break;
		}
	}

	public void PickupWeapon (WeaponType weapon){
		PlayerWeaponBehavior weaponBehavior = this.GetComponent<PlayerWeaponBehavior> ();

		if (weaponBehavior.weaponObject.GetComponent<Weapon> ().type == weapon) {
			this.RechargeAmmo ();
		} else {
			this.EquipWeapon (weapon);
		}
	}

	private void EquipWeapon (WeaponType weapon){
		PlayerWeaponBehavior weaponBehavior = this.GetComponent<PlayerWeaponBehavior> ();

		GameObject.Destroy (weaponBehavior.weaponObject);
		weaponBehavior.LoadWeapon (weapon);
		if (this.activatedWeapons [(int)weapon] == false) {
			this.activatedWeapons [(int)weapon] = true;
		}
	}

	public void RechargeAmmo(){
		for (int i = 0; i < this.curTotalWeaponAmmo.Length; i++) {
			this.curTotalWeaponAmmo [i] = this.maxTotalWeaponAmmo [i];
		}
	}

	private void Reload(){

	}

	private void SwitchWeapons(){
		PlayerWeaponBehavior weaponBehavior = this.GetComponent<PlayerWeaponBehavior> ();
		if (weaponBehavior.weaponObject.GetComponent<Weapon> ().type == WeaponType.MAIN) {
			if (this.activatedWeapons [1] == true) {

			}
		}
	}
}

