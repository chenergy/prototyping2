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
		if (this.weaponObject != null){
			this.weaponObject = GameObject.Instantiate(this.weaponObject, this.weaponLocation.position, this.weaponObject.transform.rotation) as GameObject;
			if (this.tag == "Player")
				this.weaponObject.transform.parent = Camera.main.transform;
			else{
				foreach (Transform t in this.GetComponentsInChildren<Transform>()) {
					if (t.name == "Mesh") {
						this.weaponObject.transform.parent = t;
						break;
					}
				}
			}
			this.weaponScript = weaponObject.GetComponent<Weapon>();
		}
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{

	}
	
	void OnDrawGizmos(){
		//Gizmos.DrawCube(this.weaponLocation.position, Vector3.one * 0.25f);
	}
}

