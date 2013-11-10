using UnityEngine;
using System.Collections;

public class EMP : MonoBehaviour
{
	public GameObject[] emitters;

	[HideInInspector]
	public Vector3 source;
	[HideInInspector]
	public float expansionRate;

	void Update(){
		this.transform.localScale *= expansionRate;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			other.GetComponent<EnemyMovementBehavior> ().state = EnemyStates.PARALYZED;
		}
	}
}

