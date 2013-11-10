using UnityEngine;
using System.Collections;

public class ProjectileTrigger : MonoBehaviour {
	[HideInInspector]
	public float damage;

	public GameObject particles;

	void OnTriggerEnter(Collider other){
		switch (other.tag){
		case "Enemy":
			EnemyMovementBehavior enemyScript = other.GetComponent<EnemyMovementBehavior> ();
			enemyScript.TakeDamage (this.damage);
			GameObject enemyParticles = GameObject.Instantiate (this.particles, 
			                                                    this.transform.position, 
			                                                    this.particles.transform.rotation) as GameObject;
			GameObject.Destroy (enemyParticles, 1.0f);
			break;
		case "Player":
			PlayerBehavior playerScript = other.GetComponent<PlayerBehavior> ();
			playerScript.ChangeHP (-this.damage);
			PlayerGUI guiScript = other.GetComponent<PlayerGUI> ();
			guiScript.ActivateDamageMesh ();
			GameObject playerParticles = GameObject.Instantiate (this.particles, 
			                                                     this.transform.position, 
			                                                     this.particles.transform.rotation) as GameObject;
			GameObject.Destroy (playerParticles, 1.0f);
			break;
		default:
			break;
		}
	}
}
