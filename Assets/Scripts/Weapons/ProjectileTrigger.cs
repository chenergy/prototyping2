using UnityEngine;
using System.Collections;

public class ProjectileTrigger : MonoBehaviour {
	[HideInInspector]
	public float damage;

	void OnTriggerEnter(Collider other){
		switch (other.tag){
		case "Enemy":
			EnemyMovementBehavior enemyScript = other.GetComponent<EnemyMovementBehavior> ();
			enemyScript.TakeDamage (this.damage);
			break;
		case "Player":
			PlayerBehavior playerScript = other.GetComponent<PlayerBehavior> ();
			playerScript.ChangeHP (-this.damage);
			PlayerGUI guiScript = other.GetComponent<PlayerGUI> ();
			guiScript.ActivateDamageMesh ();
			break;
		default:
			break;
		}
	}
}
