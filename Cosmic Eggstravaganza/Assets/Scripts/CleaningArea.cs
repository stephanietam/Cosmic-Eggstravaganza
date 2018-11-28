using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CleaningArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Creature moved to cleaning area");
		Vector2 pos = new Vector2 (0, 0);
		Debug.Log (transform.position);
		Debug.Log (col.gameObject.transform.position);
		col.gameObject.transform.localPosition = transform.localPosition;
		Debug.Log (col.gameObject.transform.position);
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Clean;
	}

	void OnTriggerExit2D(Collider2D col) {
		Debug.Log ("Creature moved out of cleaning area");
		Creature creature = col.gameObject.GetComponent<Creature> ();
		creature.location = Area.Stable;
		Debug.Log (creature.hygene.GetPoints());
	}
}
