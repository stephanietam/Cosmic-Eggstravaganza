using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class CleaningArea : MonoBehaviour {
	int colliders = 0;
	public AreaTracking areaTracker;

	void OnTriggerEnter2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Clean;
		areaTracker.setArea(Area.Clean);
	}

	void OnTriggerExit2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		if (creature.location == Area.Clean) {
			creature.location = Area.None;
			areaTracker.setArea (Area.None);
		}
	}
}
