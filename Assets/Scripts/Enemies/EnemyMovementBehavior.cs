using UnityEngine;
using System.Collections;

public enum EnemyStates{
	PATROL, MOVE, ATTACK, IDLE, DEATH, PARALYZED
};

[RequireComponent(typeof(EnemyWeaponBehavior))]
public class EnemyMovementBehavior : MonoBehaviour
{
	public GameObject			mesh;
	public GameObject			sparks;
	public GameObject 			deathParticles;
	public Transform[]			sparkPoints;
	public Transform[]			patrolPoints;
	public bool 				useGravity 			= true;
	public float 				maxMoveRange 		= 5.0f;
	public float				patrolRange 		= 5.0f;
	public float				patrolIdleTime 		= 2.0f;
	public float				moveSpeed			= 1.0f;
	public float				health				= 100.0f;
	public float 				maxHealth 			= 100.0f;
	public float				paralyzedDuration 	= 5.0f;
	
	[HideInInspector]
	public EnemyStates 			state = EnemyStates.IDLE;
	[HideInInspector]
	public	bool 				isAlly = false;
	[HideInInspector]
	public GameObject			target;

	private Transform			targetPatrolPoint;
	private CharacterController controller;
	private float 				startY;
	private int 				currentPatrolPointNum 	= 0;
	private float				idleTimer 				= 0;
	private float				paralyzedTimer 			= 0;
	private float 				sparkTimer 				= 0;
	private int 				patrolListDirection 	= 1;
	
	void Start(){
		this.controller = this.GetComponent<CharacterController>();
		this.startY = this.controller.transform.position.y;
	}
	
	void Update(){
		// Check health state
		if (this.health <= 0.0f)
			this.state = EnemyStates.DEATH;

		if (this.useGravity) {
			/*this.controller.transform.position = new Vector3 (this.controller.transform.position.x,
			                                                 this.startY,
			                                                 this.controller.transform.position.z);*/
			this.AddGravity ();
		}

		// State Machine control system
		switch (this.state){
		case EnemyStates.PATROL:
			if (!this.isAlly) {
				if (this.patrolPoints.Length > 0) {
					if ((this.controller.transform.position - new Vector3(this.targetPatrolPoint.transform.position.x,
					                                                      this.controller.transform.position.y,
					                                                      this.targetPatrolPoint.transform.position.z)).magnitude < 0.1f) {
						this.idleTimer = 0.0f;
						this.state = EnemyStates.IDLE;
					} else {
						if (this.mesh.animation.GetClip("walk") != null) 
							this.mesh.animation.Play ("walk");
						this.Patrol ();
					}
				}
			}
			break;
		case EnemyStates.ATTACK:
			if ((this.controller.transform.position - this.target.transform.position).magnitude > this.maxMoveRange) {
				if (this.mesh.animation.GetClip("walk") != null) 
					this.mesh.animation.Play ("walk");
				this.MoveTowardsTarget ();
			}
			this.AttackTarget();
			break;
		case EnemyStates.IDLE:
			this.mesh.animation.Stop ();
			if (!this.isAlly) {
				if (this.idleTimer >= this.patrolIdleTime) {
					this.SetNewPatrolPoint ();
					this.state = EnemyStates.PATROL;
				} else {
					this.idleTimer += Time.deltaTime;
				}
			}
			break;
		case EnemyStates.PARALYZED:
			if (!this.isAlly){
				if (this.paralyzedTimer >= this.paralyzedDuration) {
					this.paralyzedTimer = 0.0f;
					this.sparkTimer = 0.0f;
					this.state = EnemyStates.ATTACK;
				} else {
					if (this.sparkTimer >= 1.0f) {
						this.CreateSparks ();
						this.sparkTimer = 0.0f;
					} else {
						this.sparkTimer += Time.deltaTime;
					}
					this.paralyzedTimer += Time.deltaTime;
				}
			}
			break;
		case EnemyStates.DEATH:
			this.Death ();
			break;
		default:
			break;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(this.transform.position, this.maxMoveRange);
	}

	// Public Externally Accessable Functions
	public void TakeDamage ( float damage ){
		if (this.state != EnemyStates.ATTACK)
			this.state = EnemyStates.ATTACK;
		this.health -= damage;
		if (this.health <= 0)
			this.state = EnemyStates.DEATH;
	}

	// Private Helper Functions
	private void SetNewPatrolPoint(){
		Debug.Log (this.currentPatrolPointNum + this.patrolListDirection);
		Debug.Log (this.patrolPoints.Length);
		if ((this.currentPatrolPointNum + this.patrolListDirection) < 0 || (this.currentPatrolPointNum + this.patrolListDirection >= this.patrolPoints.Length)) {
			this.patrolListDirection *= -1;
		}
		this.targetPatrolPoint = this.patrolPoints [this.currentPatrolPointNum + this.patrolListDirection];
		this.currentPatrolPointNum += this.patrolListDirection;
	}

	private void MoveTowardsTarget(){
		this.controller.Move( (this.target.transform.position - this.controller.transform.position).normalized * this.moveSpeed * Time.deltaTime );
	}

	private void AttackTarget(){
		this.controller.transform.rotation = Quaternion.Slerp (this.controller.transform.rotation,
		                                                       Quaternion.LookRotation ((new Vector3 (this.target.transform.position.x,
		                                                                                             this.controller.transform.position.y,
		                                                                                             this.target.transform.position.z) - this.controller.transform.position)),
		                                                       Time.deltaTime * 5.0f);
	}

	private void Patrol(){
		Quaternion targetRotation = Quaternion.Slerp (this.controller.transform.rotation,
		                                              Quaternion.LookRotation ((new Vector3 (this.targetPatrolPoint.transform.position.x,
		                                                                                     this.controller.transform.position.y,
		                                                                                     this.targetPatrolPoint.transform.position.z) - this.controller.transform.position)),
		                                              Time.deltaTime * 5.0f);
		this.controller.transform.Rotate (targetRotation.eulerAngles - this.controller.transform.rotation.eulerAngles);
		this.controller.Move( (new Vector3(this.targetPatrolPoint.transform.position.x, 
		                                   this.controller.transform.position.y,
		                                   this.targetPatrolPoint.transform.position.z) - this.controller.transform.position).normalized * this.moveSpeed * Time.deltaTime );
	}

	private void Death(){

		GameObject.Destroy (this.gameObject);
	}

	private void AddGravity(){
		if (!this.controller.isGrounded) {
			this.controller.Move (Physics.gravity * Time.deltaTime);
		}
	}

	private void CreateSparks(){
		foreach (Transform sparkLocation in this.sparkPoints) {
			GameObject newSpark = GameObject.Instantiate (this.sparks, sparkLocation.position, this.sparks.transform.rotation) as GameObject;
			GameObject.Destroy (newSpark, 0.75f);
		}
	}
}

