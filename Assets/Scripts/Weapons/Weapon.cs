using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	public Transform 	shootLocation;
	public GameObject 	projectile;
	public float		weaponSpeed = 1.0f;
	public float		firingInterval = 0.25f;
	
	private float 		firingTimer = 0.0f;
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		if (Input.GetMouseButton(0)){
			this.firingTimer += Time.deltaTime;
		}else{
			this.firingTimer = this.firingInterval;
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.DrawSphere(this.shootLocation.position, 0.25f);
	}
	
	public virtual void Fire(){
		if (this.firingTimer >= this.firingInterval){
			GameObject newProjectile = GameObject.Instantiate(this.projectile, this.shootLocation.position, this.projectile.transform.rotation) as GameObject;
			newProjectile.rigidbody.velocity = Camera.main.transform.forward * this.weaponSpeed;
			GameObject.Destroy( newProjectile, 2.0f );
			this.firingTimer = 0.0f;
		}
	}
}

