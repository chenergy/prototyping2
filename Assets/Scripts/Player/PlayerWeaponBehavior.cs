using UnityEngine;
using System.Collections;

public class PlayerWeaponBehavior : WeaponBehavior
{
	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		if (Input.GetMouseButton (0)) {
			this.weaponObject.transform.position = Vector3.Lerp (this.weaponObject.transform.position, 
			                                                     Camera.main.transform.TransformPoint (new Vector3 (0.2f, -0.7f, 0.0f)),
			                                                     Time.deltaTime * 5);
			if (this.weaponScript != null) {
				this.firingTimer += Time.deltaTime;
				if (this.firingTimer >= this.weaponScript.firingInterval) {
					this.weaponScript.Fire ();
					this.firingTimer = 0.0f;
				}
			}
			/* else {
				this.firingTimer = this.weaponScript.firingInterval;
			}*/
		} else {
			this.weaponObject.transform.position = Vector3.Lerp (this.weaponObject.transform.position, this.weaponLocation.position, Time.deltaTime * 5);
			if (this.firingTimer < this.weaponScript.firingInterval) {
				this.firingTimer += Time.deltaTime;
			}
		}

		base.Update();
	}
}

