using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	
	// Use this for initialization
	void Start () {
		text.text = "hello";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			text.text = "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed," +
						" a mirror on the wall, and the door is locked from the outside.\n\nPress S to view sheets," +
						" M to view Mirror, and L to view lock.";
	}
}
