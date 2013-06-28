/******************************************
  * uWebKit 
  * (c) 2012 8 bit buffalo
  * josh@uwebkit.com
*******************************************/

using UnityEngine;
using UWK;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Minimal WebGUI using uWebKit and Unity GUI
/// </summary>
public class WebGUI : MonoBehaviour
{
	
	// URL 
	public string URL = "http://0.0.0.0:3000/unity";

	// position 
	public int X = 40;
	public int Y = 10;
	
	// dimensions
	public int Width = 600;
	public int Height = 400; 
	
	// transparency
	public float Transparency = 100.0f;
	
	// the view itself
	public UWKView View;
	
	private static string message_from_web = "";
	
	private bool bound = false;

	void Start ()
	{		
		// Create the view
		View = UWKCore.CreateView ("MashFX-Unity", URL, Width, Height);				
	} 
	
	void OnGUI ()
	{
		// Draw the view
		View.OnWebGUI(X, Y, Width, Height, Transparency);
		
		string txt;
		if (message_from_web == "") {
			txt = "...waiting for message from browser....";
		}
		else {
			txt = message_from_web;
		}
		GUI.Label (new Rect (10, 5, 600, 20), txt);
		
		View.EvaluateJavaScript("get_msg();", evalResult);
	}
	
	
	void evalResult (object sender, CommandProcessEventArgs args){
		Command cmd = args.Cmd;
	
		string result = Plugin.GetString(cmd.iParams[0], cmd.iParams[1]);
	
		Debug.Log(result);
		message_from_web = result;
	}
	
}
