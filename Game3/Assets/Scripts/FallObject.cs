using UnityEngine;
using System.Collections;

public class FallObject : MonoBehaviour {
	
	public	GameObject box ;
	public	Vector3 position ;
	public int side;
	private bool isFall;
	// Use this for initialization
	void Start () {
		box = GameObject.Find ("Box");
		position = new Vector3(3,-12,35);
		side = 3;
		isFall = false;
		//frozenAll();
	}
	
	// Update is called once per frame
	void Update () {
		while(transform.childCount < 20)
		makeRandom(box, 4, position, 4, 2 );
			
//		if(isFall)
//			fallEach();
	}
	void makeRandom (GameObject child, int side, Vector3 top, int quantity, float diameter)
	{
		ArrayList xflArray = new ArrayList();
		ArrayList zflArray = new ArrayList();
		for(int i = 0; i < quantity; i++)
		{
			//float random = diameter * (int)Random.Range(0, side);
			float x = 0;
			float z = 0;
			int j = 0;
			
			
			while(j < 1000)
			{		
				
				x = top.x - diameter * (int)Random.Range(0, side);
			    z = top.z + diameter * (int)Random.Range(0, side);
				//Debug.Log(!xflArray.Contains(x) + " " +!zflArray.Contains(z));
				j++;				
				if (!(xflArray.Contains((int)x) && zflArray.Contains((int)z)))
				{
			Debug.Log(!(xflArray.Contains((int)x) && zflArray.Contains((int)z)));
					
					j=0;					
					xflArray.Add((int)x);
					zflArray.Add((int)z);
					break;
				}
			}
			
			Debug.Log("x: " + x + " z: " + z);
			createChild(child, new Vector3(x, top.y, z)).transform.parent = transform;
		}
		isFall = true;
	}
	void makeRound(GameObject child, int side, Vector3 top)
	{
		if(side == 1)
		{
			createChild(box,top).transform.parent = transform;
		}
		else if (side == 2)
		{
			createChild(child, top).transform.parent = transform;
			top.x = top.x - 2;
			createChild(child, top).transform.parent = transform;
			top.z = top.z + 2;
			createChild(child, top).transform.parent = transform;
			top.x = top.x + 2;
			createChild(child, top).transform.parent = transform;
		}
		else
		if(side >=3)
		{
			int otherside = side - 2;
			createChild(child, top).transform.parent = transform;			
			for(int i = 0; i < side - 1; i++)
			{
			top.x = top.x - 2;				
			createChild(child, top).transform.parent = transform;
			}
			for(int i = 0; i < otherside + 1; i++)
			{
			top.z = top.z + 2;				
			createChild(child, top).transform.parent = transform;
			}
			for(int i = 0; i < side - 1; i++)
			{
			top.x = top.x + 2;												
			createChild(child, top).transform.parent = transform;
			}
			for(int i = 0; i < otherside; i++)
			{
			top.z = top.z - 2;				
			createChild(child, top).transform.parent = transform;
			}
		}
		
	}
	GameObject createChild(GameObject child, Vector3 position)
	{
		GameObject clone = Instantiate(child, position, child.transform.rotation) as GameObject;
		clone.name = "clone";
		//clone.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		
		//clone.SetActive(true);
		return clone;
	}
	void frozenAll()
	{
		int count = transform.childCount;
		for(int i = 0; i < count;i++)
		{
			GameObject obj = transform.GetChild(i).gameObject;
			obj.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
	private int n = -1;
	void fallEach()
	{
		int count = transform.childCount;
		//Debug.Log(count);
		
		if(Time.fixedTime <= count && (int)Time.fixedTime > n)
		{
			n = (int) Time.fixedTime;
			GameObject obj = transform.GetChild(n).gameObject;
			obj.rigidbody.constraints = new RigidbodyConstraints();
			obj.rigidbody.constraints = RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.FreezePositionX|RigidbodyConstraints.FreezePositionZ;
			Debug.Log(n);
			
			//obj.
			
		}
		
	}
}
