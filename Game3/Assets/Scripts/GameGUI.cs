using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour
{
	// Use this for initialization
	private Main main;
	public int option;
	private int op;
	private int menuLevel;
	public Texture2D Background;
	//public Texture2D Logo, Background;
	void Start ()
	{
		
		Time.timeScale = 1;
		main = GameObject.Find ("Robot").GetComponent<Main> ();
		if (option != null)
			op = option;
		else {
			op = 0;
			option = 0;
		}
		//
		if (menuLevel == null)
			menuLevel = 0;
	}
	
	// Update is called once per frame
	private float time;
	private int level;

	void Update ()
	{
		if (option >= 0) {
			time = main.getTime ();
			level = main.getLevel ();
			if (Input.GetKeyDown ("r")) {
				Application.LoadLevel (Application.loadedLevel);
				
			} else if (Input.GetKeyDown ("escape")) {
				pause_resume ();			
				op = (op == 1 ? option : 1);
			}
		}
	}

	void OnGUI ()
	{
		//Debug.Log (time + " " + level);
		
		if (op == 0) {
			playingGUI ();
		} else if (op == 1) {
			playingMenuGUI ();
		} else if (op == 2) {
			
			showWin ();
		} else if (op == 3) {
			showLose ();
		} else if (op < 0) {
			showMenuGUI ();
		}
	}

	void playingMenuGUI ()
	{
		GUIStyle centeredStyle;
		int w = 200;
		int h = 350;
		GUI.BeginGroup (new Rect (Screen.width / 2 - w / 2, 100, w, h));
		//
		centeredStyle = "Box";
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (0, 0, w, h), "", centeredStyle);
		//
		int wb = 100;
		int hb = 30;
		int space = 1;
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.hover.textColor = Color.yellow;
		if (GUI.Button (new Rect (w / 2 - wb / 2, space * hb, wb, hb), "Resume", centeredStyle)) {
			op = (op == 1 ? option : 1);
			pause_resume ();
		}
		if (menuLevel == 0) {
			space += 2;
		
			//
			if (GUI.Button (new Rect (w / 2 - wb / 2, space * hb, wb, hb), "Main Menu", centeredStyle)) {
				Application.LoadLevel (Application.loadedLevel - level);
			}
			space += 2;
		
		
			//
			if (GUI.Button (new Rect (w / 2 - wb / 2, space * hb, wb, hb), "Change Level", centeredStyle)) {
				menuLevel = 1;
			}
			space += 2;
		
		
			//
			if (GUI.Button (new Rect (w / 2 - wb / 2, space * hb, wb, hb), "Restart", centeredStyle)) {
				Application.LoadLevel (Application.loadedLevel);
			}
			space += 2;
		
		
			//
			if (GUI.Button (new Rect (w / 2 - wb / 2, space * hb, wb, hb), "Quit Game", centeredStyle)) {
				Application.Quit ();
			}
		} else if (menuLevel == 1) {
			space += 2;
			
			if (GUI.Button (new Rect (w / 2 - wb / 2, hb * space, wb, hb), "level 1", centeredStyle)) {
				Application.LoadLevel (1);
			}
			space += 2;
			
			if (GUI.Button (new Rect (w / 2 - wb / 2,  hb * space, wb, hb), "level 2", centeredStyle)) {
				Application.LoadLevel (2);
				
			}
			space += 2;
			
			if (GUI.Button (new Rect (w / 2 - wb / 2,  hb * space, wb, hb), "level 3", centeredStyle)) {
				Application.LoadLevel (3);
					
			}
		}
		GUI.EndGroup ();
		
	}

	void playingGUI ()
	{
		GUIStyle centeredStyle;
			
		int w = Screen.width;
		int h = 50;
		GUI.BeginGroup (new Rect (0, 0, w, h + 10));
		//
		centeredStyle = "Box";
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (0, 0, w, h), "", centeredStyle);
		//
		centeredStyle = "Label";
		centeredStyle.alignment = TextAnchor.UpperLeft;
		centeredStyle.fontSize = 25;	
		centeredStyle.normal.textColor = Color.white;			
		GUI.Label (new Rect (10, 10, 250, 100), "Level: " + level, centeredStyle);
		centeredStyle = "Label";			
		centeredStyle.normal.textColor = Color.red;
		GUI.Label (new Rect (150, 10, 250, 100), "Time: " + (int)time, centeredStyle);
		//
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.hover.textColor = Color.yellow;
			
		//
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (w - 200, 10, 80, 30), "Restart(R)", centeredStyle)) {
			Application.LoadLevel (Application.loadedLevel);
		}
		//
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (w - 100, 10, 80, 30), "Menu(Esc)", centeredStyle)) {
			op = (op == 1 ? option : 1);
			pause_resume ();
				
		}
		GUI.EndGroup ();
	}

	void pause_resume ()
	{
		Time.timeScale = (Time.timeScale + 1) % 2;		
	}

	public void setWin ()
	{
		option = 2;
		op = option;
		pause_resume ();
		
	}

	public void setLose ()
	{
		option = 3;
		op = option;
	}

	void showWin ()
	{
		GUIStyle centeredStyle;
		int w = 300;
		int h = 300;
		GUI.BeginGroup (new Rect (Screen.width / 2 - w / 2, Screen.height / 2 - h / 2, w, h));
		//
		centeredStyle = "Box";
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (0, 0, w, h), "", centeredStyle);
		//
		centeredStyle = "Label";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.fontSize = 40;	
		centeredStyle.normal.textColor = Color.white;			
		GUI.Label (new Rect (0, 50, w, 150), "Level: " + level + "\n\nCOMPLETED!", centeredStyle);
		//
		int wb = 70;
		int hb = 30;
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.hover.textColor = Color.yellow;
		
		if (GUI.Button (new Rect (10, h - hb - 10, wb, hb), "Menu", centeredStyle)) {
			Application.LoadLevel (Application.loadedLevel - level);
					
		}
		if (GUI.Button (new Rect (w / 2 - wb / 2, h - hb - 10, wb, hb), "Restart", centeredStyle)) {
			Application.LoadLevel (Application.loadedLevel);
							
		}
		if (GUI.Button (new Rect (w - 10 - wb, h - hb - 10, wb, hb), "Next", centeredStyle)) {
			Application.LoadLevel (Application.loadedLevel + 1);
							
		}
		GUI.EndGroup ();
		
	}

	void showLose ()
	{
		GUIStyle centeredStyle;
		int w = 300;
		int h = 300;
		GUI.BeginGroup (new Rect (Screen.width / 2 - w / 2, Screen.height / 2 - h / 2, w, h));
		//
		centeredStyle = "Box";
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (0, 0, w, h), "", centeredStyle);
		//
		centeredStyle = "Label";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.fontSize = 40;	
		centeredStyle.normal.textColor = Color.white;			
		GUI.Label (new Rect (0, 50, w, 150), "Level: " + level + "\n\nFAIL!", centeredStyle);
		//
		int wb = 70;
		int hb = 30;
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.hover.textColor = Color.yellow;
		
		if (GUI.Button (new Rect (10, h - hb - 10, wb, hb), "Menu", centeredStyle)) {
			Application.LoadLevel (Application.loadedLevel - level);
					
		}
		if (GUI.Button (new Rect (w / 2 - wb / 2, h - hb - 10, wb, hb), "Restart", centeredStyle)) {
			Application.LoadLevel (Application.loadedLevel);
							
		}
		if (GUI.Button (new Rect (w - 10 - wb, h - hb - 10, wb, hb), "Quit", centeredStyle)) {
			Application.Quit ();							
		}
		GUI.EndGroup ();
	}

	void showMenuGUI ()
	{
		
		GUIStyle centeredStyle;
		int w = 300;
		int h = 300;
		GUI.BeginGroup (new Rect (Screen.width - w - 100, Screen.height / 2 - h / 2, w, h));
		//
		if (Background != null)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Background);
		centeredStyle = "Box";
		centeredStyle.alignment = TextAnchor.UpperCenter;
		GUI.Box (new Rect (0, 0, w, h), "", centeredStyle);
		//
		//
		//
		centeredStyle = "Label";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.fontSize = 25;	
		centeredStyle.normal.textColor = Color.white;			
		GUI.Label (new Rect (0, 10, w, 100), "Don't Wait \nToo Lo......oong!", centeredStyle);
		//
		int wb = 150;
		int hb = 30;
		int space = 80;
		centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		centeredStyle.hover.textColor = Color.yellow;
		if (menuLevel == 0) {
			if (GUI.Button (new Rect (w / 2 - wb / 2, hb + space, wb, hb), "Start Game", centeredStyle)) {
				menuLevel = 1;
			}
			if (GUI.Button (new Rect (w / 2 - wb / 2, 3 * hb + space, wb, hb), "How To Play", centeredStyle)) {
				menuLevel = 2;		
			}
			if (GUI.Button (new Rect (w / 2 - wb / 2, 5 * hb + space, wb, hb), "Quit Game", centeredStyle)) {
				Application.Quit ();		
			}
		} else if (menuLevel == 1) {
			if (GUI.Button (new Rect (w / 2 - wb / 2, hb + space, wb, hb), "level 1", centeredStyle)) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
			if (GUI.Button (new Rect (w / 2 - wb / 2, 3 * hb + space, wb, hb), "level 2", centeredStyle)) {
				Application.LoadLevel (Application.loadedLevel + 2);
				
			}
			if (GUI.Button (new Rect (w / 2 - wb / 2, 5 * hb + space, wb, hb), "level 3", centeredStyle)) {
				Application.LoadLevel (Application.loadedLevel + 3);
					
			}
		} else if (menuLevel == 2) {
			
			if (GUI.Button (new Rect (w / 2 - wb / 2, 6* hb + space, wb, hb), "Back", centeredStyle)) {
				menuLevel = 0;
			}
			centeredStyle = "Label";
			centeredStyle.alignment = TextAnchor.MiddleCenter;
			centeredStyle.fontSize = 15;	
			centeredStyle.normal.textColor = Color.white;	
			string text = "---CONTROLS---\n--A,S,D,W: move--\n--Space: jump--\n\n" +
						  "---RULES---\n--Green: final--\n--Yellow: continue--\n--White: hint--\n--Black: surprise--";
			GUI.Label (new Rect (w / 2 - wb / 2, space, wb, 6 * hb), text, centeredStyle);
		}
		GUI.EndGroup ();
		
	}
}
