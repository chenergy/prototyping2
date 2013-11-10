using UnityEngine;
using System.Collections;

public class PickupAmmo : MonoBehaviour {
	
	public float curAmmo=100;
	public float maxAmmo=100;
	
	void ChangeAmmo(float Change)
	{

		curAmmo+=Change;
		
		if(curAmmo>maxAmmo)
		{
			curAmmo=100;
		}
		
		if(curAmmo<=0)
		{
			Debug.Log("Out of Ammo!");
		}
	}	

	
	void OnTriggerEnter(Collider other)
	{
		switch(other.gameObject.tag){
		case "Small Ammo": // The gameobject tag: "Small Ammo"
			ChangeAmmo(25);
			break;
		case "Ammo 50%": // The gameobject tag: "Ammo 50%"
			ChangeAmmo(50);
			break;
		case "Full Ammo": // The gameobject tag: "Full Ammo"
			ChangeAmmo(100);
			break;
		}
		Destroy(other.gameObject);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
