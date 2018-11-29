using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class AreaTracking : MonoBehaviour
{

	public Area activeArea;

	public void setArea(Area area) {
		activeArea = area;
	}
}

