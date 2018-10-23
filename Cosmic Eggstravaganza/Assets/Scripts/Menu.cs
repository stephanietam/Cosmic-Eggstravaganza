using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
	// modes (determines what menu shows up):
	// 0 = none
	// 1 = pets
	// 2 = inventory
	// 3 = shop
	// 4 = options
	private int currentMode;

	public GameObject panel;
	public Text panelTitle;

	// Use this for initialization
	void Start ()
	{
		panel.SetActive (false);
		this.currentMode = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.currentMode == 0) {
			panel.SetActive (false);
		} else {
			panel.SetActive (true);
			if (this.currentMode == 1) {
				Debug.Log ("Pets button clicked");
				panelTitle.text = "Pets";
			} else if (this.currentMode == 2) {
				Debug.Log ("Inventory button clicked");
				panelTitle.text = "Inventory";
			} else if (this.currentMode == 3) {
				Debug.Log ("Shop button clicked");
				panelTitle.text = "Shop";
			} else if (this.currentMode == 4) {
				Debug.Log ("Options button clicked");
				panelTitle.text = "Options";
			}
		}
	}

	public void ClosePanel()
	{
		this.currentMode = 0;
	}

	public void SetPets()
	{
		this.currentMode = 1;
	}

	public void SetInventory()
	{
		this.currentMode = 2;
	}

	public void SetShop()
	{
		this.currentMode = 3;
	}

	public void SetOptions()
	{
		this.currentMode = 4;
	}
}