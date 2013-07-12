using UnityEngine;
using System.Collections;

public class Demon : MonoBehaviour
{
	public int health;
	private Animator anim;
	private GameObject p ;
	private GameObject q ;
	public bool attacking = false;
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	static int attackState = Animator.StringToHash ("Base Layer.attack");			// these integers are references to our animator's states
	static int hardAttackState = Animator.StringToHash ("Base Layer.hardattack");			// these integers are references to our animator's states
	static int hurtState = Animator.StringToHash ("Base Layer.hurt");			// these integers are references to our animator's states
	static int hintState = Animator.StringToHash ("Base Layer.hintHardAttack");			// these integers are references to our animator's states
	
	private GameObject clone;
	public Texture2D healthBar;
	
	void Start ()
	{
		health = 110;
		anim = GetComponent<Animator> ();
		p = GameObject.Find ("SmallRockWeapon");
		p.SetActive (false);
		q = GameObject.Find ("BigRockWeapon");
		q.SetActive (false);
		//clone = Instantiate( p, p.transform.position, p.transform.rotation) as GameObject;
		//clone.name = "RockWeaponClone";
		
	}

	private float time = 0;
	// Update is called once per frame
	void Update ()
	{
		
		
		
		if (!clone) {
			attacking = false;
		} else if (attacking) {
			throwRock (clone);
			
		}
		currentBaseState = anim.GetCurrentAnimatorStateInfo (0);
		if (currentBaseState.nameHash == attackState) {
			anim.SetBool ("attack", false);
		} else if (currentBaseState.nameHash == hardAttackState) {
			anim.SetBool ("hardattack", false);
			
		} else if (currentBaseState.nameHash == hurtState) {
			anim.SetBool ("hurt", false);
			
		} else if (currentBaseState.nameHash == hintState) {
			anim.SetBool ("hint", false);
		}
			
	}

	void throwRock (GameObject rock)
	{
		//p.transform.position = vRock;
		if (Time.time - time >= 0.5) {
			rock.SetActive (true);
			
			if (rock.name.Contains ("Small")) {
				rock.transform.Translate (10 * Time.deltaTime, 0, 0);
			}
			if (rock.name.Contains ("Big")) {
				rock.transform.Translate (17 * Time.deltaTime, -17 * Time.deltaTime, 0);
				
			}
		}
	}

	public void attack ()
	{
		anim.SetBool ("attack", true);
		clone = new GameObject ();
		clone = Instantiate (p, p.transform.position, p.transform.rotation) as GameObject;
		clone.name = "SmallRock";
		p.SetActive (false);
		attacking = true;
		time = Time.time;
	}

	public void hardattack ()
	{
		anim.SetBool ("hardattack", true);
		clone = new GameObject ();
		clone = Instantiate (q, q.transform.position, q.transform.rotation) as GameObject;
		clone.name = "BigRock";
		q.SetActive (false);
		attacking = true;
		time = Time.time;
	}

	public void gethint ()
	{
		anim.SetBool ("hint", true);
	}

	void OnTriggerEnter (Collider col)
	{
		GameObject gObj = col.gameObject;
		Debug.Log (gObj.name);
		if (gObj.name == "SmallChop") {
			{
				health = health - 15;
				Debug.Log ("Demon health = " + health);
			}
		
			if (health <= 0) {
				anim.SetBool ("die", true);
				Debug.Log ("Demon dies");
				Hero heroScr = (Hero)GameObject.Find ("SpartanKing").GetComponent (typeof(Hero));
				if(heroScr.health > 0)
				Application.LoadLevel(2);
					
				
			} else {
				anim.SetBool ("hurt", true);
				Debug.Log ("Demon is hurt");
			}
			Destroy (gObj);
			
		}
	}

	int getHealth ()
	{
		return health;
	}

	public void die ()
	{
		anim.SetBool ("die", true);
	}

	public string toString ()
	{
		return "Demon Class";
	}
	void OnGUI ()
	{
		GUI.BeginGroup(new Rect (Screen.width / 2 , 10, 440, 50));
		if (healthBar != null)
			GUI.DrawTexture (new Rect (health*4-440, 0, 440, 50), healthBar);
		GUI.EndGroup();
	}
}
