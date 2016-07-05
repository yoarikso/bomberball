using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUICanvas : MonoBehaviour {
	
	public Font font;

	private bool isVisible = false;

	// Use this for initialization
	void Start () {
		isVisible = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause();
		}
	}

	void OnGUI()
	{
		if(isVisible)
		{
			// gameover text
			string gameOverText = string.Format ("<size=40><color=black>{0}</color></size>", "Game. over.");
			GUI.skin.font = font;
			GUI.Label (new Rect (0.5f * Screen.width - 120, 0.5f * Screen.height - 42, 300, 50), gameOverText);

			// retry button
			GUI.skin.font = font;
			GUIStyle buttonStyle = new GUIStyle("button");
			buttonStyle.alignment = TextAnchor.UpperCenter;
			string retryText = string.Format ("<size=30><color=white>{0}</color></size>", "Retry.");
			if(GUI.Button (new Rect (0.5f * Screen.width - 75, 0.5f * Screen.height + 10, 150, 40), retryText, buttonStyle))
			{
				RestartGame();
			}
		}
	}

	public void TogglePause()
	{
		// toggle canvas; and then toggle pause time
		isVisible = !isVisible;
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}

	public void RestartGame()
	{
		// reload level
		Application.LoadLevel (0);
		
		// make sure we are unpausing
		Time.timeScale = 1;
	}
	
	public void Quit()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
