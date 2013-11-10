using UnityEngine;
using System.Collections;

public class PlayerEMPBehavior : MonoBehaviour
{
	public GameObject 	EMP;
	public float 		expansionRate 	= 1.1f;
	public float		duration		= 1.0f;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			GameObject newEMP = GameObject.Instantiate (this.EMP, this.transform.position, this.EMP.transform.rotation) as GameObject;
			EMP script = newEMP.GetComponent<EMP> ();
			script.source = this.transform.position;
			script.expansionRate = this.expansionRate;
			GameObject.Destroy (newEMP, this.duration);
		}
	}
}

