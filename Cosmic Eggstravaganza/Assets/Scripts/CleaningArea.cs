using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CleaningArea : MonoBehaviour {
	public AreaTracking areaTracker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Creature moved to cleaning area");
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Clean;
		areaTracker.setArea(Area.Clean);
	}

	void OnTriggerExit2D(Collider2D col) {
		Debug.Log ("Creature moved out of cleaning area");
		Creature creature = col.gameObject.GetComponent<Creature> ();
		if (creature.location == Area.Clean) {
			creature.location = Area.None;
			areaTracker.setArea(Area.None);
		}
	}
}
