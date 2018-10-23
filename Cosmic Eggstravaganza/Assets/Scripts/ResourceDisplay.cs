using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceDisplay : MonoBehaviour
{
	public GameState gameState;
	public Text foodText;
	public Text starsText;

	// Use this for initialization
	void Start ()
	{
		SetFood();
		SetStars();
	}
	
	// Update is called once per frame
	void Update ()
	{
		SetFood();
		SetStars();
	}

	void SetFood ()
	{
		foodText.text = gameState.GetFood().ToString() + " Food";
	}

	void SetStars ()
	{
		starsText.text = gameState.GetStars().ToString() + " Stars";
	}
}

