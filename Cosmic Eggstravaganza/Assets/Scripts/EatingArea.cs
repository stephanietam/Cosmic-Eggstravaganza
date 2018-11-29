using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class EatingArea : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Creature moved to eating area");
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Eat;
	}

	void OnTriggerExit2D(Collider2D col) {
		Debug.Log ("Creature moved out of eating area");
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Stable;
	}
}

