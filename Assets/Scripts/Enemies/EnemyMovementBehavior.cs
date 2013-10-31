using UnityEngine;
using System.Collections;

public enum EnemyStates{
	PATROL, MOVE, ATTACK, IDLE
};

public class EnemyMovementBehavior : MonoBehaviour
{
	public float 				agroRange 		= 10.0f;
	public float 				attackRange 	= 5.0f;
	public float				patrolRange 	= 5.0f;
	public float				patrolIdleTime 	= 2.0f;
	public float				moveSpeed		= 1.0f;
	
	private EnemyStates 		state = EnemyStates.IDLE;
	private Vector3				startLocation;
	private Vector3				targetPatrolLocation;
	private float				idleTimer;
	private CharacterController controller;
	
	
	void Start(){
		this.startLocation = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
		this.controller = this.GetComponent<CharacterController>();
	}
	
	void Update(){
		switch (this.state){
		case EnemyStates.PATROL:
			if ((this.controller.transform.position - this.targetPatrolLocation).magnitude < 0.01f){
				this.controller.transform.position = this.targetPatrolLocation;
				this.idleTimer = 0.0f;
				this.state = EnemyStates.IDLE;
			}else{
				this.controller.Move( (this.targetPatrolLocation - this.controller.transform.position) * this.moveSpeed * Time.deltaTime );
			}
			break;
		case EnemyStates.ATTACK:
			break;
		case EnemyStates.MOVE:
			break;
		case EnemyStates.IDLE:
			if (this.idleTimer >= this.patrolIdleTime){
				Vector3 thisLocation = new Vector3(this.controller.transform.position.x, 0.0f, this.controller.transform.position.z);
				
				if (thisLocation.Equals(this.startLocation)){
					this.targetPatrolLocation = this.controller.transform.position + new Vector3(Random.Range(-this.patrolRange, this.patrolRange), 0.0f, Random.Range(-this.patrolRange, this.patrolRange));
				}else{
					this.targetPatrolLocation = this.startLocation + new Vector3(0.0f, this.controller.transform.position.y, 0.0f);
				}
				
				this.state = EnemyStates.PATROL;
			}else{
				this.idleTimer += Time.deltaTime;
			}
			break;
		default:
			break;
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(this.transform.position, this.agroRange);
		Gizmos.DrawWireSphere(this.transform.position, this.attackRange);
	}
}

