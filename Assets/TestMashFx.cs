using UnityEngine;
using System.Collections;

public class TestMashFx : MonoBehaviour {
	
	WebGUI webGUI;
	
	// Use this for initialization
	void Start () {
		webGUI = GameObject.FindObjectOfType (typeof(WebGUI)) as WebGUI;			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
