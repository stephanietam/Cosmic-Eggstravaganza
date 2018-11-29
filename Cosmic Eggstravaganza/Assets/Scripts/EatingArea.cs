using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class EatingArea : MonoBehaviour
{
	public AreaTracking areaTracker;

	void OnTriggerEnter2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Eat;
		areaTracker.setArea(Area.Eat);
	}

	void OnTriggerExit2D(Collider2D col) {
		Creature creature = col.gameObject.GetComponent<Creature>();
		if (creature.location == Area.Eat) {
			creature.location = Area.None;
			areaTracker.setArea(Area.None);
		}
	}
}

