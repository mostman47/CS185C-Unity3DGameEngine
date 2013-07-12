using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
	private Animator anim;
	private GameObject wallAttack;
	private GameObject clone;
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	static int resistState = Animator.StringToHash ("Base Layer.resist");
	static int attackState = Animator.StringToHash ("Base Layer.attack");// these integers are references to our animator's states
	static int hurtState = Animator.StringToHash ("Base Layer.hurt");			// these integers are references to our animator's states
	private bool attacking = false;
	private float time = 0;
	public bool isResist = false;
	public int health;
	public Texture2D healthBar;
	// Use this for initialization
	void Start ()
	{
		
		anim = GetComponent<Animator> ();	
		health = 100;
		wallAttack = GameObject.Find ("AttackTrigger");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	
		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if (currentBaseState.nameHash == hurtState) {
			anim.SetBool ("hurt", false);
		} else if (currentBaseState.nameHash == attackState) {
			anim.SetBool ("attack", false);
		} else if (currentBaseState.nameHash == resistState) {
			anim.SetBool ("resist", false);
			isResist = false;
		}
		if (!clone) {
			attacking = false;
		}
			else
		if (attacking) {
			
			makeAttack (clone);
		}
	}
	
	void OnTriggerEnter (Collider col)
	{
		GameObject gObj = col.gameObject;
		if (gObj.name.Contains ("Small")) {
			if (!isResist)
				health = health - 5;
			Debug.Log ("Hero health = " + health);
		} else if (gObj.name.Contains ("Big")) {
			if (!isResist)
				health = health - 50;
			else
				health = health - 10;
			Debug.Log ("Hero health = " + health);
		}
		if (health <= 0) {
			anim.SetBool ("die", true);
			Debug.Log ("Hero dies");
			Application.LoadLevel(3);
			
		} else if (isResist) {
			resist ();
		} else {
			anim.SetBool ("hurt", true);
			Debug.Log ("Hero is hurt");
		}
		
		Destroy (gObj);
		
	}

	public void attack ()
	{
		anim.SetBool ("attack", true);
		attacking = true;
		time = Time.time;
		clone = new GameObject ();
		clone = Instantiate (wallAttack, wallAttack.transform.position, wallAttack.transform.rotation) as GameObject;
		clone.name = "SmallChop";
		Debug.Log ("Small chop");
	}

	void makeAttack (GameObject att)
	{
		if (Time.time - time >= 0.5) {
			
			att.transform.Translate (-10 * Time.deltaTime, 0, 0);
			
		}
	}

	public void resist ()
	{
		anim.SetBool ("resist", true);
	}

	void OnTriggerExit (Collider col)
	{
		//anim.SetBool ("resist", false);
		
	}

	public string toString ()
	{
		return "Hero Class";
	}
	
	void OnGUI ()
	{
		GUI.BeginGroup(new Rect (Screen.width / 2 - 450, 10, 400, 50));
		if (healthBar != null)
			GUI.DrawTexture (new Rect (400-health*4, 0, 400, 50), healthBar);
		GUI.EndGroup();
	}
}
