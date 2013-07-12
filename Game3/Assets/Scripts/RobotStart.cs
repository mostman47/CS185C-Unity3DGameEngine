using UnityEngine;
using System.Collections;

public class RobotStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.animation.Play("Wave");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
