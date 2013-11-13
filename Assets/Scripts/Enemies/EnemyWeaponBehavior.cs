using UnityEngine;
using System.Collections;

public class EnemyWeaponBehavior : WeaponBehavior
{
	private EnemyMovementBehavior behavior;
	// Use this for initialization
	protected override void Start ()
	{
		this.behavior = this.GetComponent<EnemyMovementBehavior> ();
		base.Start ();
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		if (this.behavior.state == EnemyStates.ATTACK) {
			if (this.weaponScript != null) {
				this.firingTimer += Time.deltaTime;
				if (this.firingTimer >= this.weaponScript.firingInterval) {
					this.weaponScript.Fire ();
					this.firingTimer = 0.0f;
				}
			} else {
				this.firingTimer = this.weaponScript.firingInterval;
			}
			base.Update();
		}
	}
}

