using UnityEngine;
using System.Collections;

public class PlayerWeaponBehavior : WeaponBehavior
{
	// Use this for initialization
	protected virtual void Start ()
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		if (Input.GetMouseButton(0)){
			if (this.weaponScript != null) {
				this.firingTimer += Time.deltaTime;
				if (this.firingTimer >= this.weaponScript.firingInterval) {
					this.weaponScript.Fire ();
					this.firingTimer = 0.0f;
				}
			} else {
				this.firingTimer = this.weaponScript.firingInterval;
			}
		}
		base.Update();
	}
}

