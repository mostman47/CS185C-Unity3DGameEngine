using UnityEngine;
using System.Collections;

public class main : MonoBehaviour
{

	// Use this for initialization
	public Demon demonScr;
	public Hero heroScr;

	void Start ()
	{
		demonScr = (Demon)GameObject.Find ("demonFrost").GetComponent (typeof(Demon));
		heroScr = (Hero)GameObject.Find ("SpartanKing").GetComponent (typeof(Hero));
		Debug.Log (demonScr.toString ());
		Debug.Log (heroScr.toString ());
		
	}

	private int set = 0;
	private int newSet = 0;
	private int demonAtt = 0;
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown("escape"))
			Application.LoadLevel(0);
		if (newSet == 0) {
			
			demonAtt = Mathf.FloorToInt(Random.value*100)% 3;
			Debug.Log(demonAtt);
			if(demonAtt == 0)
				demonScr.gethint();
			newSet++;
		} else 
		if(newSet == 1){
			if (Input.GetKeyDown (KeyCode.A)) {
				makeAttack();
				newSet++;
				Debug.Log ("a");				
			} else if (Input.GetKeyDown (KeyCode.S)) {
				makeResist();
				newSet++;
				Debug.Log ("s");
			} else if (Input.GetKeyDown (KeyCode.Z)) {
				demonScr.attack ();
				Debug.Log ("a");
			
			} else if (Input.GetKeyDown (KeyCode.X)) {
				demonScr.hardattack ();
				Debug.Log ("a");
			
			}
		}
		else{
//			if(heroScr.health <=0)
//			{
//				Debug.Log ("Defeat");
//				//Application.LoadLevel(4);
//				newSet++;
//			}
//			else
//			if(demonScr.health <=0)
//			{
//				Debug.Log ("Victory");
//				//Application.LoadLevel(3);
//				newSet++;
//			}
//				else
			newSet = 0;
		}
	}
	void makeAttack()
	{
		heroScr.attack ();	
		if(demonAtt == 0)
		{
			demonScr.hardattack();
		}
		else{
			demonScr.attack();
		}
	}
	void makeResist()
	{
		heroScr.isResist = true;
		if(demonAtt == 0)
		{
			demonScr.hardattack();
		}
		else{
			demonScr.attack();
		}
		
	}
}
