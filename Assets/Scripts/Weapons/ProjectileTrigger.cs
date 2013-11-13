using UnityEngine;
using System.Collections;

public class ProjectileTrigger : MonoBehaviour {
	[HideInInspector]
	public float damage;
	[HideInInspector]
	public GameObject source;

	public GameObject particles;

	void OnTriggerEnter(Collider other){
		switch (other.tag){
		case "Enemy":
			EnemyMovementBehavior enemyScript = other.GetComponent<EnemyMovementBehavior> ();
			if (enemyScript.isAlly) {
				if (this.source.Equals(GameObject.FindGameObjectWithTag("Player"))){
					enemyScript.target = this.source;
				}
			} else {
				enemyScript.target = GameObject.FindGameObjectWithTag ("Player");
			}
			enemyScript.TakeDamage (this.damage);
			GameObject enemyParticles = GameObject.Instantiate (this.particles, 
			                                                    this.transform.position, 
			                                                    this.particles.transform.rotation) as GameObject;
			GameObject.Destroy (enemyParticles, 1.0f);
			GameObject.Destroy (this.gameObject);
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
			GameObject.Destroy (this.gameObject);
			break;
		case "Obstacle":
			GameObject obstacleParticles = GameObject.Instantiate (this.particles, 
			                                                       this.transform.position, 
			                                                       this.particles.transform.rotation) as GameObject;
			GameObject.Destroy (obstacleParticles, 1.0f);
			GameObject.Destroy (this.gameObject);
			break;
		default:
			break;
		}
	}
}
