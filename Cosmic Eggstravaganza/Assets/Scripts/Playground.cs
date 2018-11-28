using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Playground : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log("Creature moved to playground");
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Playground;
	}

	void OnTriggerExit2D(Collider2D col) {
		Debug.Log ("Creature moved out of playground");
		Creature creature = col.gameObject.GetComponent<Creature>();
		creature.location = Area.Stable;
	}

}
