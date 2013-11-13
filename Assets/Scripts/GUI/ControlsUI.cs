using UnityEngine;
using System.Collections;

public class ControlsUI : MonoBehaviour {
	public GUIStyle leftJustified;
	public GUIStyle rightJustified;
	
	void OnGUI(){
		GUI.Box(new Rect(20,0,200,100), 
			"Left Click - Fire\n" +
			"Right Click - EMP\n",
			leftJustified);
		GUI.Box(new Rect(Screen.width - 220,0,200,100), 
			"W - Forward\n" +
			"A - Left\n" +
			"D - Right\n" +
			"S - Back\n" +
			"Space - Jump",
			rightJustified);
	}
}
