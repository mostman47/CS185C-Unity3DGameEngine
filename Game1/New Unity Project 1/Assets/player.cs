using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public float speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
		gameObject.transform.Translate(speed * Input.GetAxis( "Horizontal" ) * Time.deltaTime, 0, 0 );			
		}
		
	}
}
