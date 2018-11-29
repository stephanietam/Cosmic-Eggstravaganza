using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Playground : MonoBehaviour {
	public AreaTracking areaTracker;

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Creature moved to playground");
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Playground;
		areaTracker.setArea(Area.Playground);
	}

	void OnTriggerExit2D(Collider2D col) {
		Debug.Log ("Creature moved out of playground");
		Creature creature = col.gameObject.GetComponent<Creature>();
		if (creature.location == Area.Playground) {
			creature.location = Area.None;
			areaTracker.setArea(Area.None);
		}
	}

}
