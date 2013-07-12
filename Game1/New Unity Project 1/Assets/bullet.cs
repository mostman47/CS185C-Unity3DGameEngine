using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
	public float speed = 1;
	public bool isFired = false;
	public int max = 8;
	public TextMesh label;
	// Use this for initialization
	void Start ()
	{
		label = (TextMesh)GameObject.Find ("Text").GetComponent ("TextMesh");	
		label.text = "8 Balls";
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		checkWin ();
		if (gameObject.transform.position.y >= 5 || gameObject.transform.position.y <= -5
			|| gameObject.transform.position.x >= 5 || gameObject.transform.position.x < -5) {
			gameObject.SetActive (false);
			isFired = false;
			var p = GameObject.Find ("Player");
			gameObject.transform.position = new Vector3 (p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);
			if (max > 0) {
				gameObject.SetActive (true);
			} else {
				checkWin ();
				
			}
			
			//lost1();
		} else if (!isFired) {
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
				gameObject.transform.Translate (speed * Input.GetAxis ("Horizontal") * Time.deltaTime, 0, 0);			
			} else if (Input.GetKey (KeyCode.Space)) {
				isFired = true;
				lost1 ();
	 			
			}
		} else {
			gameObject.transform.Translate (0, 5 * Time.deltaTime, 0);
			
		}
		
		//
		
		
		
	}

	void checkWin ()
	{
		GameObject[] arr = GameObject.FindGameObjectsWithTag ("Cube");
		//print (isFired +" " + arr.Length);
		if (arr.Length == 0) {
			label.text = "Win";
			Destroy (this);
		} else if (max == 0) {
			if (isFired == false)
			{
				label.text = "Game        Over";
			gameObject.SetActive (false);
			}
		}		
	}
				
	void lost1 ()
	{
		max--;
		label.text = max + (max > 1 ? " balls" : " ball");
		
	}

	void OnCollisionEnter (Collision obj)
	{                
		var p = GameObject.Find ("Player");
		gameObject.transform.position = new Vector3 (p.transform.position.x, p.transform.position.y + 1, p.transform.position.z);
		
		isFired = false;
		
		
	}
}
