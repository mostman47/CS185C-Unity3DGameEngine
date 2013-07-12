using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour {
	private Animator anim;
	
	// Use this for initialization
	void Start () {
	//anim = GetComponent<Animator>();					  
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		GameObject enemy = col.gameObject;
		Animator a = enemy.GetComponent<Animator>();
		a.SetBool("die",true);
		
	}
}
