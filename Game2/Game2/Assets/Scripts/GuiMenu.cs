using UnityEngine;
using System.Collections;

public class GuiMenu : MonoBehaviour
{

	public Texture2D Logo, Background;
	public int option;

	void OnGUI ()
	{
		if (Background != null)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), Background);
		GUIStyle centeredStyle = "Button";
		centeredStyle.alignment = TextAnchor.MiddleCenter;
		// Constrain all drawing to be within a 800x600 pixel area centered on the screen.
		int hLogo = 250;
		int hPanel = hLogo + 20;
		int w = 120;
		if (Logo != null)
			GUI.DrawTexture (new Rect (Screen.width / 2 - w, 10, hLogo, hLogo), Logo);
		
		
		if (option == 0) {
		
		GUI.Box (new Rect (Screen.width / 2 - w, hPanel, 250, 300), "");
	
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 320, 150, 30), "--Star Game--", centeredStyle)) {
				Application.LoadLevel (1);
			}

			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 370, 150, 30), "--How to Play--", centeredStyle)) {
				option = 1;
			}
		
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 420, 150, 30), "--About--", centeredStyle)) {
				option = 2;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 470, 150, 30), "--End Game--", centeredStyle)) {
				Application.Quit ();
			}
        
		}
		else 
			if(option == 1)
		{
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 520, 150, 30), "--Back--", centeredStyle	)) {
				option = 0;
			}
			centeredStyle = "Box";
			centeredStyle.alignment = TextAnchor.UpperCenter;
			GUI.Box (new Rect (Screen.width / 2 - w, hPanel, 250, 300), "--How To Play--", centeredStyle);
			hPanel += 40;			
			centeredStyle = "Label";
			centeredStyle.alignment = TextAnchor.UpperLeft;
			centeredStyle.fontSize = 12;
			
			string text = "**Conditions**\n\n -Win: enemy dies and hero is still alive\n -Lose: hero dies";
				text +="\n\n\n**Controls**\n\n -key \'a\' : attack enemy with sword \n -key \'s\' : shield, block or reduce enemy's attack\n -key 'Esc' : back to main menu";
			GUI.Label(new Rect (Screen.width / 2 - w, hPanel, 250, 200), text,centeredStyle);
			
		}
		else 
			if(option == 2)
		{
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 520, 150, 30), "--Back--", centeredStyle	)) {
				option = 0;
			}
			centeredStyle = "Box";
			centeredStyle.alignment = TextAnchor.UpperCenter;
			GUI.Box (new Rect (Screen.width / 2 - w, hPanel, 250, 300), "--About--", centeredStyle);
			hPanel += 40;			
			centeredStyle = "Label";
			centeredStyle.alignment = TextAnchor.UpperLeft;
			centeredStyle.fontSize = 12;
			
			string text = "**San Jose State University - CS 185C**\n\n -Spring 2013\n\n -Project 1";
				text +="\n\n\n**Team Go4It**\n\n -Nam Phan";
			GUI.Label(new Rect (Screen.width / 2 - w, hPanel, 250, 200), text,centeredStyle);
		}
		else
			if(option == 3)
		{
			GUI.Box (new Rect (Screen.width / 2 - w, hPanel, 250, 300), "");
			
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 370, 150, 30), "--Play again--", centeredStyle)) {
				Application.LoadLevel (1);
			}
		
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 420, 150, 30), "--Main Menu--", centeredStyle)) {
				Application.LoadLevel (0);
			}
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 470, 150, 30), "--End Game--", centeredStyle)) {
				Application.Quit ();
			}
			centeredStyle = "Label";
			centeredStyle.alignment = TextAnchor.UpperCenter;
			
			centeredStyle.fontSize = 60;
			GUI.Label(new Rect (Screen.width / 2 - w, 280, 250, 200), "WIN",centeredStyle);
			
		}
		else 
			if(option == 4)
		{
			GUI.Box (new Rect (Screen.width / 2 - w, hPanel, 250, 300), "");
			
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 370, 150, 30), "--Play again--", centeredStyle)) {
				Application.LoadLevel (1);
			}
		
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 420, 150, 30), "--Main Menu--", centeredStyle)) {
				Application.LoadLevel (0);
			}
			if (GUI.Button (new Rect (Screen.width / 2 - w + 50, 470, 150, 30), "--End Game--", centeredStyle)) {
				Application.Quit ();
			}
			centeredStyle = "Label";
			centeredStyle.alignment = TextAnchor.UpperCenter;
			
			centeredStyle.fontSize = 35;
			GUI.Label(new Rect (Screen.width / 2 - w, 280, 250, 200), "GAME OVER",centeredStyle);
		}
	}
}
