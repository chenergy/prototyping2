using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour
{
	// Crosshair
	public Texture2D crossHair;

	// Damage Indicator
	public GameObject damageMesh;

	void Start(){
		this.damageMesh.renderer.material.color = new Color(255, 0, 0, 0);
		this.damageMesh.renderer.enabled = true;
	}

	// Update is called once per frame
	void Update ()
	{
		Color newColor = new Color (255, 0, 0, Mathf.Lerp (this.damageMesh.renderer.material.color.a, 0.0f, Time.deltaTime));
		this.damageMesh.renderer.material.color = newColor;
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2 - this.crossHair.width/2, Screen.height/2 - this.crossHair.height, this.crossHair.width, this.crossHair.height), this.crossHair);
	}

	public void ActivateDamageMesh(){
		this.damageMesh.renderer.material.color = new Color(255.0f, 0.0f, 0.0f, 0.5f);
	}
}

