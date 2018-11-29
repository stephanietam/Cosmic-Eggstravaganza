using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Gym : MonoBehaviour
{
	public AreaTracking areaTracker;

	void OnTriggerEnter2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Gym;
		areaTracker.setArea(Area.Gym);
	}

	void OnTriggerExit2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		if (creature.location == Area.Gym) {
			creature.location = Area.None;
			areaTracker.setArea(Area.None);
		}
	}
}

