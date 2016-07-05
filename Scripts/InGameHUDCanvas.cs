using UnityEngine;
using System.Collections;

public class InGameHUDCanvas : MonoBehaviour {

	public Texture2D image;
	public Font font;
	public Spawner spawner;

	int score;

	private float imageScaleFactor = 0.3f;
	//private float cameraHeight = 0.0f;
	//private float cameraWidth = 0.0f;

	// Use this for initialization
	void Start () {
		//Camera camera = GetComponent<Camera> ();
		//cameraHeight = camera.pixelHeight;
		//cameraWidth = camera.pixelWidth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		string result = string.Empty;
		score = spawner.Score;
		if(score < 10) {
			result = string.Format("<size=20>0{0}</size>", score);
		} 
		else {
			result = string.Format ("<size=20>{0}</size>", score);
		}

		//GUI.Button (new Rect (0.5f * cameraWidth , 0.5f * cameraHeight, 100, 30), "I am a Fixed Layout Button");
		GUI.DrawTexture(new Rect(0.005f * Screen.width, 0.01f * Screen.height, imageScaleFactor * 314, imageScaleFactor * 278), image);

		// score
		GUI.skin.font = font;
		GUI.Label (new Rect (78.0f, 65.0f, 68, 30), result);
	}
}
