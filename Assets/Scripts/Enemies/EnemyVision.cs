using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour
{
	private EnemyMovementBehavior enemyMovement;

	void Start(){
		this.enemyMovement = this.transform.parent.parent.GetComponent<EnemyMovementBehavior> ();
	}

	void OnTriggerEnter( Collider other ){
		if (other.tag == "Player") {
			this.enemyMovement.state = EnemyStates.ATTACK;
		}
	}
}

