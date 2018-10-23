using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
    public GameState gameState;
    public Text moneyText;

	// Use this for initialization
	public void Start () {
        SetStars(moneyText);
    }
	
	// Update is called once per frame
	public void Update () {
        SetStars(moneyText);
    }

    public void SetStars(Text text)
    {
        text.text = gameState.GetStars().ToString() + " Stars";
    }
}
