using UnityEngine;
using System.Collections;

public class BasicWeapon : Weapon {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
	
	public override void Fire(){
		Debug.Log("Firing Basic Weapon");
		base.Fire();
	}
}
