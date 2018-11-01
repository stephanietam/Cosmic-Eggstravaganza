﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour {
	// source: http://unity.grogansoft.com/drag-and-drop/
	Vector2 currentMousePosition {
		get {
			Vector2 inputPos;
			inputPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			return inputPos;
		}
	}
	bool mouseDown {
		get {
			return Input.GetMouseButton (0); // true if mouse down
		}
	}
	bool draggingObject;
	GameObject obj;

	// Use this for initialization
	void Start () {
		draggingObject = false;
	}

	// Update is called once per frame
	void Update () {
		if (mouseDown) {
			Drag ();
		} 
		else {
			if (draggingObject) {
				Drop ();
			}
		}
	}

	void Drag() {
		Vector2 position = currentMousePosition;
		if (draggingObject) {
			obj.transform.position = position;
		}
		else {
			RaycastHit2D[] touches = Physics2D.RaycastAll(position, position, 0.5f);
			if (touches.Length > 0)
			{
				var hit = touches[0];
				if (hit.transform != null)
				{
					draggingObject = true;
					obj = hit.transform.gameObject;
					//obj.transform.localScale = new Vector3(1f,1f,1f);
				}
			}
		}
	}

	void Drop() {
		draggingObject = false;
		//obj.transform.localScale = new Vector3(1f,1f,1f);
	}
}
