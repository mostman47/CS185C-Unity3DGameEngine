using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	private GameGUI gui;
	public int level;
	public	GameObject box ;
	public	Vector3 position ;
	//private bool isFall;
	private float time;
	private string hint = "";
	// Use this for initialization
	private int direction = 1;
	private int level3_TimeFall = 4;
	void Start ()
	{
		gui = GameObject.Find ("Main Camera").GetComponent<GameGUI> ();		
		//isFall = false;
		//Debug.Log(time);
		
		if (level != null) {
			if (level == 1) {
				box = GameObject.Find ("Box");
				position = box.transform.position;
				
				time = 20;
			} else if (level == 2) {
				//GameObject.Find("BoxGroupCondition1").SetActive(false);
				time = 60;
			} else if (level == 3)
				time = 40;
		}
		//Debug.Log(time);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (time > 0) {
			//Debug.Log (time);
			setTime (time - Time.deltaTime);
			if (time < 0) {
				
				if (level == 1) {
					level1End (GameObject.Find ("Box"), 5, 5);
				} else if (level == 2) {
					level2End (GameObject.Find ("Box1"), 10, 10);
				} else if (level == 3) {
					Destroy (gameObject);
					setLose();
				}
				
			} else {
			
				if (level == 2) {
					Debug.Log (GameObject.Find ("BoxGroup3").gameObject.transform.childCount);
					
					if (time < 30 && GameObject.Find ("BoxGroup3").gameObject.transform.childCount == 0) {
						GameObject groupBox3 = GameObject.Find ("BoxGroup3").gameObject;
						GameObject box3 = GameObject.Find ("Box3").gameObject;
						float x = box3.transform.position.x;
						float y = box3.transform.position.y;
						float z = box3.transform.position.z;
						for (int i = 0; i < 4; i++) {
							for (int j = 0; j < 2; j++) {
								GameObject clone = createChild (box3, new Vector3 (x - 2 - 2 * i, y, z + 2 * j));
								clone.transform.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX
								| RigidbodyConstraints.FreezePositionZ;
								clone.transform.Translate (0, Time.deltaTime, 0);
								clone.transform.parent = groupBox3.transform;
							}
						}
					}
					if (hint != "") {
						GameObject hintObj = GameObject.Find (hint).gameObject;
						int speed = 2;
						
						if (hint == "GroupBox3") {
							GameObject final = GameObject.Find ("final").gameObject;
							float diff = final.transform.position.x - hintObj.transform.position.x;
							if ((diff > 2 && direction == 1) || (diff < 6 && direction == -1)) {
								float sp = Time.deltaTime;
								hintObj.transform.Translate (sp * speed * direction, 0, sp * speed * direction);

								//transform.position= new Vector3(hintObj.transform.position.x,
								//	transform.position.y,hintObj.transform.position.z);//(sp * speed, 0, sp * speed);
							} else {
								direction = direction * -1;
							}
						} else {
							if (hintObj.transform.position.y < 9) {
								hintObj.transform.Translate (0, Time.deltaTime * speed, 0);
							} else {
								//Debug.Log (hintObj.transform.rotation.y);
								hintObj.transform.Rotate (0, Time.deltaTime * speed * 10, 0);
								transform.Rotate (0, Time.deltaTime * speed * 10, 0);
							
							}
						}
					}
				}
				else if(level == 3)
				{
					int tmp= (int)time/6;
					if(tmp == level3_TimeFall )
					{
						level2End (GameObject.Find ("Box1"), 10, 10);
						level3_TimeFall --;
					}
						
				}
			}
			
		}
//		if (isFall)
//			fallEach (GameObject.Find ("BoxGroup1"));
	}

	public void setWin ()
	{
		gui.setWin ();
	}

	public void setLose ()
	{
		gui.setLose ();
	}
	//
	public void setTime (float t)
	{
		time = t;
	}

	public float getTime ()
	{
		return time;
	}

	public int getLevel ()
	{
		return level;
	}
	//
	void level1End (GameObject obj, int row, int col)
	{
		for (int i = 0; i < obj.transform.childCount; i++) {
			GameObject t = obj.transform.GetChild (i).gameObject;
			if (t != null && t.name.Equals ("boxtrigger"))
				t.SetActive (true);
		 
		}
		GameObject groupEnd = GameObject.Find ("EndBox");
		float x = obj.transform.position.x;
		float y = obj.transform.position.y;
		float z = obj.transform.position.z;
		for (int i = 0; i < row; i++) {
			for (int j = 0; j <col; j++) {
				createChild (obj, new Vector3 (x - 2 * i, y + 10, z + 2 * j)).transform.parent = groupEnd.transform;			
				
			}
		}
	}
	//
	void level2End (GameObject obj, int row, int col)
	{
		GameObject groupEnd = GameObject.Find ("EndBox");
		GameObject final = GameObject.Find ("final");
		
		float x = final.transform.position.x;
		float y = final.transform.position.y;
		float z = final.transform.position.z;
		for (int i = 0; i < row; i++) {
			for (int j = 0; j <col; j++) {
				createChild (obj, new Vector3 (x - 2 * i, 20, z - 2 * j)).transform.parent = groupEnd.transform;			
				
			}
		}
	}

	void runLevel1 (Collider col)
	{
		GameObject groupBox0 = GameObject.Find ("BoxGroup0");
		GameObject groupBox1 = GameObject.Find ("BoxGroup1");
		GameObject groupBox2 = GameObject.Find ("BoxGroup2");
		float x;
		float y;
		float z;
		if (col.gameObject.name == "trigger0" && groupBox0.transform.childCount == 0) {
			x = box.transform.position.x;
			y = box.transform.position.y;
			z = box.transform.position.z;
			for (int i =0; i< 4; i++) {
				createChild (box, new Vector3 (x, y, z + 2 + 2 * i)).transform.parent = groupBox0.transform;			
			}
		} else if (col.gameObject.name == "trigger1" && groupBox1.transform.childCount == 0) {
			GameObject box1 = GameObject.Find ("Box1");
			x = box1.transform.position.x;
			y = box1.transform.position.y;
			z = box1.transform.position.z;
			for (int i =0; i< 4; i++) {
				for (int j = 0; j < 2; j++) {
					createChild (box1, new Vector3 (x - 2 - 2 * i, y - 2 * j, z)).transform.parent = groupBox1.transform;			
				}
			}
		} else if (col.gameObject.name == "trigger2" && groupBox2.transform.childCount == 0) {
			GameObject box2 = GameObject.Find ("Box2");
			x = box2.transform.position.x;
			y = box2.transform.position.y;
			z = box2.transform.position.z;
			for (int i =0; i< 4; i++) {
				for (int j = 0; j < 3; j++) {
					createChild (box2, new Vector3 (x, y - 2 * j, z - 2 - 2 * i)).transform.parent = groupBox2.transform;			
				}
			}
		}
	}

	void runLevel2 (Collider col)
	{
		GameObject groupBox1 = GameObject.Find ("BoxGroup1");
		GameObject groupBox2 = GameObject.Find ("BoxGroup2");
		float x;
		float y;
		float z;
		if (col.gameObject.name == "trigger1" && groupBox1.transform.childCount == 0) {
			GameObject box1 = GameObject.Find ("Box1");
			x = box1.transform.position.x;
			y = box1.transform.position.y;
			z = box1.transform.position.z;
			for (int i =0; i< 4; i++) {
				createChild (box1, new Vector3 (x + 2 + 2 * i, y, z)).transform.parent = groupBox1.transform;			
				createChild (box1, new Vector3 (x - 2 - 2 * i, y, z)).transform.parent = groupBox1.transform;			
				createChild (box1, new Vector3 (x, y, z + 2 + 2 * i)).transform.parent = groupBox1.transform;			
				createChild (box1, new Vector3 (x, y, z - 2 - 2 * i)).transform.parent = groupBox1.transform;			
				
			}
			GameObject groupCond = GameObject.Find ("BoxGroupCondition1");
			for (int i = 0; i < groupCond.transform.childCount; i++)
				groupCond.transform.GetChild (i).gameObject.SetActive (true);
		} else if (col.gameObject.name == "triggerGo" && groupBox2.transform.childCount == 0) {
			GameObject box2 = GameObject.Find ("Box2").gameObject;
			x = box2.transform.position.x;
			y = box2.transform.position.y;
			z = box2.transform.position.z;
			for (int i = 0; i < 4; i++) {
				for (int j = 0; j <= i; j ++) {
					createChild (box2, new Vector3 (x + 2 + 2 * i, y + 2 * j, z)).transform.parent = groupBox2.transform;			
					if (j > 0)
						createChild (box2, new Vector3 (x + 2 + 2 * i, y + 2 * j, z - 2)).transform.parent = groupBox2.transform;			
						
				}
			}
				
		} else if (col.gameObject.name == "trigger3") {
			hint = col.gameObject.transform.parent.gameObject.name;
		} else if (col.gameObject.name == "triggerDead") {
			Vector3 newP = new Vector3 (col.gameObject.transform.position.x,
				col.gameObject.transform.position.y + 10, col.gameObject.transform.position.z);
			GameObject dead = createChild (col.gameObject.transform.parent.gameObject, newP);
			for (int i = 0; i < dead.transform.childCount; i++) {
				GameObject child = dead.transform.GetChild (i).gameObject;
				if (child.name.Equals ("boxtrigger"))
					child.SetActive (true);
			}
			
			dead.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX |
				RigidbodyConstraints.FreezePositionZ;
		} else if (col.gameObject.name == "triggerHint" && hint == "") {
			hint = col.gameObject.transform.parent.gameObject.name;
			//col.gameObject.SetActive (false);
		}
		
		
	}

	void runLevel3 ()
	{
//		int height = 7;
//		GameObject groupBox = GameObject.Find ("BoxGroup0");		
//		float x = box.transform.position.x;
//		float y = box.transform.position.y;
//		float z = box.transform.position.z;
//		
//		for (int i =0; i< height; i++) {
//			y += 2;
//			createChild (box, new Vector3 (x, y, z)).transform.parent = groupBox.transform;			
//		}
//		GameObject final = GameObject.Find ("Final");
//		final.transform.position = new Vector3 (x, y + 2, z);
//		//
//		GameObject groupbox1 = GameObject.Find ("BoxGroup1");
//		
//		while (groupbox1.transform.childCount < 20)
//			makeRandom (box, groupbox1, 20, new Vector3 (x, y, z), 4, 2);
//		frozenAll (groupbox1);	
		
	}

	GameObject createChild (GameObject child, Vector3 position)
	{
		GameObject clone = Instantiate (child, position, child.transform.rotation) as GameObject;
		clone.name = "clone";
		//clone.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		
		//clone.SetActive(true);
		return clone;
	}

//	void makeRandom (GameObject child, GameObject parent, int side, Vector3 top, int quantity, float diameter)
//	{
//		ArrayList xflArray = new ArrayList ();
//		ArrayList zflArray = new ArrayList ();
//		for (int i = 0; i < quantity; i++) {
//			//float random = diameter * (int)Random.Range(0, side);
//			float x = 0;
//			float z = 0;
//			int j = 0;
//			
//			
//			while (j < 1000) {		
//				
//				x = top.x - diameter * (int)Random.Range (0, side);
//				z = top.z + diameter * (int)Random.Range (0, side);
//				//Debug.Log(!xflArray.Contains(x) + " " +!zflArray.Contains(z));
//				j++;				
//				if (!(xflArray.Contains ((int)x) && zflArray.Contains ((int)z))) {
//					//Debug.Log (!(xflArray.Contains ((int)x) && zflArray.Contains ((int)z)));
//					
//					j = 0;					
//					xflArray.Add ((int)x);
//					zflArray.Add ((int)z);
//					break;
//				}
//			}
//			
//			//Debug.Log ("x: " + x + " z: " + z);
//			createChild (child, new Vector3 (x, top.y, z)).transform.parent = parent.transform;
//		}
//		isFall = true;
//	}
//
//	private int n = -1;
//
//	void frozenAll (GameObject groupObj)
//	{
//		int count = groupObj.transform.childCount;
//		for (int i = 0; i < count; i++) {
//			GameObject obj = groupObj.transform.GetChild (i).gameObject;
//			obj.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
//		}
//	}
//
//	void fallEach (GameObject groupObj)
//	{
//		int count = groupObj.transform.childCount;
//		//Debug.Log(count);
//		
//		if (Time.fixedTime < count) {
//			if ((int)Time.fixedTime > n) {
//				n = (int)Time.fixedTime;
//				GameObject obj = groupObj.transform.GetChild (n).gameObject;
//				obj.rigidbody.constraints = new RigidbodyConstraints ();
//				obj.rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
//				obj.transform.Translate (0, 1, 0);
//				//Debug.Log ("n:" + n + isFall);
//			
//				//obj.
//			}
//		} else
//			isFall = false;
//		
//	}

	void OnTriggerEnter (Collider col)
	{
		if (level == 1) {
			runLevel1 (col);
			
		} else if (level == 2 || level == 3) {
			runLevel2 (col);
			
		}
		
	}
}
