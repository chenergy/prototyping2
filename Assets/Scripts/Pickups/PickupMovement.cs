using UnityEngine;
using System.Collections;

public class PickupMovement : MonoBehaviour {
	private int timer;
	private float[] sineTable;

	public bool spin = true;
	public bool oscillate = true;
	public int speedReduction = 100;
	// Use this for initialization
	void Start () {
		this.sineTable = new float[360 * this.speedReduction];
		for (int i = 0; i < (360 * this.speedReduction); i++) {
			this.sineTable [i] = Mathf.Sin (((float)i)/((float)this.speedReduction));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.timer >= (360 * this.speedReduction))
			this.timer = 0;
		if (this.oscillate)
			this.transform.position = new Vector3 (this.transform.position.x, this.sineTable [this.timer] * 0.5f, this.transform.position.z);
		if (this.spin)
			this.transform.rotation = Quaternion.Euler (0.0f, ((float)this.timer * 20) / ((float)this.speedReduction), 0.0f);
		this.timer++;
	}

	void OnGUI()
	{

	}	
}
