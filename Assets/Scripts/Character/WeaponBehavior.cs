using UnityEngine;
using System.Collections;

public class WeaponBehavior : MonoBehaviour
{
	public GameObject 	weaponObject;
	public Transform 	weaponLocation;
	
	protected Weapon	weaponScript;
	protected float 	firingTimer = 0.0f;
	// Use this for initialization
	protected virtual void Start ()
	{
		//if (this.weaponObject != null){
		this.LoadWeapon (this.weaponObject.GetComponent<Weapon> ().type);
		//}
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{

	}
	
	void OnDrawGizmos(){
		//Gizmos.DrawCube(this.weaponLocation.position, Vector3.one * 0.25f);
	}

	public void LoadWeapon(WeaponType type){
		switch(type){
		case WeaponType.MAIN:
			this.weaponObject = GameObject.Instantiate(Resources.Load("Weapons/MainWeapon", typeof(GameObject)) as GameObject, this.weaponLocation.position, this.transform.rotation) as GameObject;
			break;
		case WeaponType.ROCKET:
			this.weaponObject = GameObject.Instantiate(Resources.Load("Weapons/RocketWeapon", typeof(GameObject)) as GameObject, this.weaponLocation.position, this.transform.rotation) as GameObject;
			break;
		default:
			break;
		}

		if (this.tag == "Player") {
			this.weaponObject.transform.parent = Camera.main.transform;
		}
		else{
			EnemyMovementBehavior behavior = this.GetComponent<EnemyMovementBehavior> ();
			this.weaponObject.transform.parent = this.weaponLocation.transform;
			this.weaponObject.transform.localPosition = Vector3.zero;
		}
		this.weaponScript = weaponObject.GetComponent<Weapon>();
		this.weaponScript.source = this.gameObject;
		this.firingTimer = this.weaponScript.firingInterval;
	}
}

