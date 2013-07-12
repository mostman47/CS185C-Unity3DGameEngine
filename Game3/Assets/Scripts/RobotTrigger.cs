using UnityEngine;
using System.Collections;

public class RobotTrigger : MonoBehaviour
{
	private Main main;
	
	// Use this for initialization
	void Start ()
	{
		main = GameObject.Find ("Robot").GetComponent<Main> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "boxtrigger") {
			//gameObject.GetComponent<BotControlScript>().enabled = false;
			Destroy (gameObject);
			main.setLose ();
		} else if (col.gameObject.name == "triggerFinal") {
			main.setWin ();
		}
	}
	
//	void OnTriggerStay(Collider col)
//	{
//		if(col.gameObject.name == "boxtrigger")
//		{
//			gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
//			//gameObject.GetComponent<BotControlScript>().enabled = false;
//			
//		}
//		Vector3 scale = gameObject.transform.localScale;		
//		if(scale.y <=0)
//			Destroy(gameObject);
//		else
//		if(col.gameObject.name == "boxtrigger")
//		{
//			gameObject.transform.localScale = new Vector3(scale.x,scale.y - Time.deltaTime,scale.z);
//		}
//	}
}
