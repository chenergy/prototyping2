using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	[HideInInspector]
	public GameObject	source;

	public WeaponType	type;
	public Transform 	shootLocation;
	public GameObject 	projectile;
	public float		projectileSpeed = 30.0f;
	public float		firingInterval 	= 0.25f;
	public float		damage 			= 10.0f;
	public float		variance		= 1.0f;
	
	// Update is called once per frame
	protected virtual void Update ()
	{

	}
	
	void OnDrawGizmos(){
		Gizmos.DrawSphere(this.shootLocation.position, 0.1f);
	}
	
	public virtual void Fire(){
		float varianceX = Random.Range (-this.variance, this.variance);
		float varianceY = Random.Range (-this.variance, this.variance);
		GameObject newProjectile = GameObject.Instantiate (this.projectile, this.shootLocation.position, this.transform.rotation) as GameObject;
		newProjectile.rigidbody.velocity = (this.gameObject.transform.forward + new Vector3 (0.0f, .03f, 0.0f)) * this.projectileSpeed + new Vector3 (varianceX, varianceY, 0.0f);
		ProjectileTrigger script = newProjectile.GetComponent<ProjectileTrigger> ();
		script.damage = this.damage;
		script.source = this.source;
		GameObject.Destroy( newProjectile, 2.0f );
	}
}

