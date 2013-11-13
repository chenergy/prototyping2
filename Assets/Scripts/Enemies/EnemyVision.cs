using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
	public EnemyMovementBehavior enemyMovement;

	void Start(){

	}

	void OnTriggerEnter( Collider other ){
		if (this.enemyMovement.isAlly) {
			if (other.tag == "Enemy") {
				this.enemyMovement.target = other.gameObject;
				this.enemyMovement.state = EnemyStates.ATTACK;
			}
		} else {
			if (other.tag == "Player") {
				//Debug.Break ();
				this.enemyMovement.target = other.gameObject;
				this.enemyMovement.state = EnemyStates.ATTACK;
			}
		}
	}
}

