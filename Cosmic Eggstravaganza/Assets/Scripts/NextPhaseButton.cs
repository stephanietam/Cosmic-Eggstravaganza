using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class NextPhaseButton : MonoBehaviour {

    public GameState gameState;
    public Text dateTimeText;

    void Start()
    {
        dateTimeText.text = gameState.GetDateTime().ToString();
    }

    public void OnClick()
    {
        // Change scene aka change background?


        // Decrease stats for all pets


        // Set time of day
        DateTime dateTime = gameState.GetDateTime();
        dateTime.NextPhase();
        
        dateTimeText.text = dateTime.ToString();
        Debug.Log(dateTimeText.text);
    }
}