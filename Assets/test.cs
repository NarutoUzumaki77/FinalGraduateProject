using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class test : MonoBehaviour {

	public GameObject prefab;

	private List<string> list1 = new List<string>();
	private float z = -5f;

	// Use this for initialization
	void Start () {
		list1.Add("-5,4");
		list1.Add("-4,4");
		list1.Add("-3,4");
		list1.Add("-2,4");
		list1.Add("-1,4");
		list1.Add("0,4");
		list1.Add("1,4");
		list1.Add("2,4");
		list1.Add("3,4");
		list1.Add("4,4");

		list1.Add("-5,3");
		list1.Add("-4,3");
		list1.Add("-3,3");
		list1.Add("-2,3");
		list1.Add("-1,3");
		list1.Add("0,3");
		list1.Add("1,3");
		list1.Add("2,3");
		list1.Add("3,3");
		list1.Add("4,3");

		list1.Add("-5,2");
		list1.Add("-4,2");
		list1.Add("-3,2");
		list1.Add("-2,2");
		list1.Add("-1,2");
		list1.Add("0,2");
		list1.Add("1,2");
		list1.Add("2,2");
		list1.Add("3,2");
		list1.Add("4,2");

		list1.Add("-5,1");
		list1.Add("-4,1");
		list1.Add("-3,1");
		list1.Add("-2,1");
		list1.Add("-1,1");
		list1.Add("0,1");
		list1.Add("1,1");
		list1.Add("2,1");
		list1.Add("3,1");
		list1.Add("4,1");

		list1.Add("-5,0");
		list1.Add("-4,0");
		list1.Add("-3,0");
		list1.Add("-2,0");
		//list1.Add("-1,0");
		list1.Add("0,0");
		list1.Add("1,0");
		list1.Add("2,0");
		list1.Add("3,0");
		list1.Add("4,0");

		list1.Add("-5,-1");
		list1.Add("-4,-1");
		list1.Add("-3,-1");
		list1.Add("-2,-1");
		//list1.Add("-1,-1");
		list1.Add("0,-1");
		list1.Add("1,-1");
		list1.Add("2,-1");
		list1.Add("3,-1");
		list1.Add("4,-1");

		list1.Add("-5,-2");
		list1.Add("-4,-2");
		list1.Add("-3,-2");
		list1.Add("-2,-2");
		list1.Add("-1,-2");
		list1.Add("0,-2");
		list1.Add("1,-2");
		list1.Add("2,-2");
		list1.Add("3,-2");
		list1.Add("4,-2");

		list1.Add("-5,-3");
		list1.Add("-4,-3");
		list1.Add("-3,-3");
		list1.Add("-2,-3");
		list1.Add("-1,-3");
		list1.Add("0,-3");
		list1.Add("1,-3");
		list1.Add("2,-3");
		list1.Add("3,-3");
		list1.Add("4,-3");

		list1.Add("-5,-4");
		list1.Add("-4,-4");
		list1.Add("-3,-4");
		list1.Add("-2,-4");
		list1.Add("-1,-4");
		list1.Add("0,-4");
		list1.Add("1,-4");
		list1.Add("2,-4");
		list1.Add("3,-4");
		list1.Add("4,-4");

		foreach (string cord in list1){
			string[] textSplit = cord.Split(',');
			float x = float.Parse(textSplit[0]);
			float y = float.Parse(textSplit[1]);

			GameObject border = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity) as GameObject;
			border.transform.parent = this.transform;
		}
	}
}
