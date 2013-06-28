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

	void Start ()
	{		
		// Create the view
		View = UWKCore.CreateView ("MashFX-Unity", URL, Width, Height);		
		Bridge.BindCallback ("Unity", "SayHello", OnSayHello);
	} 
	
	void OnGUI ()
	{
		// Draw the view
		View.OnWebGUI(X, Y, Width, Height, Transparency);
		
		if (message_from_web != "") {
			GUI.Label (new Rect (10, 5, 600, 20), message_from_web);
		}
	}
	
	// Example delegate called as a callback from Javascript on the page
	public static void OnSayHello (object sender, BridgeEventArgs args)
	{
		if (args.Args.Length == 3 && args.Args[0] == "1" && args.Args[1] == "Testing123" && args.Args[2] == "45678")
			message_from_web = "Hello -- The UWebKit JavaScript Bridge is alive and well!";
		else
			message_from_web = "Hello -- The UWebKit JavaScript Bridge callback was invoked, but args were wrong!";	
	}
	
}
