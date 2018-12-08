using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Stable : MonoBehaviour
{
	public AreaTracking areaTracker;

	void OnTriggerEnter2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Stable;
		areaTracker.setArea(Area.Stable);
	}

	void OnTriggerExit2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		if (creature.location == Area.Stable) {
			creature.location = Area.None;
			areaTracker.setArea(Area.None);
		}
	}
}

