using UnityEngine;
using System.Collections;

public class WeaponBehavior : MonoBehaviour
{
	public GameObject weaponObject;
	public Transform weaponLocation;
	
	private Weapon	weaponScript;
	// Use this for initialization
	protected virtual void Start ()
	{
		if (this.weaponObject != null){
			this.weaponObject = GameObject.Instantiate(this.weaponObject, this.weaponLocation.position, this.weaponObject.transform.rotation) as GameObject;
			this.weaponObject.transform.parent = Camera.main.transform;
			this.weaponScript = weaponObject.GetComponent<Weapon>();
		}
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		if (Input.GetMouseButton(0)){
			if (this.weaponScript != null){
				this.weaponScript.Fire();
			}
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.DrawCube(this.weaponLocation.position, Vector3.one * 0.25f);
	}
}

