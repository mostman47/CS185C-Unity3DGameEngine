using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public int health = 1;
void OnCollisionEnter( Collision obj ) {
                --health;
if( health <= 0 ) {
                        Destroy ( gameObject );
}
        }
}
