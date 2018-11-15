using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButtons : MonoBehaviour
{
    public Text starsQuantity;

    public GameState gameState;

    public GameObject panelPopup;

    public Text panelPopupText;

    public GameObject backgroundCover;

    // Use this for initialization
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();

        // Hide all the creatures
        List<GameObject> creatures = this.gameState.GetCreatureObjects();
        for (int i = creatures.Count - 1; i >= 0; --i)
        {
            creatures[i].SetActive(false);
        }
    }

    public void BuyEgg()
    {
        if (this.gameState.GetStars() - 50 >= 0)
        {
            // buying egg
            this.gameState.AddStars(-50);

            // Create gameobject
            this.gameState.CreateCreature();
            Popup("You bought an egg!");
        }
        else
        {
            // pop up warning
            Popup("You don't have enough stars!");
        }
    }

    public void BuyFood()
    {
        if (this.gameState.GetStars() - 10 >= 0)
        {
            // buying food
            this.gameState.AddStars(-10);
            this.gameState.AddFood(1);
            Popup("You bought food!");
        }
        else
        {
            Popup("You don't have enough stars!");
        }
    }

    public void BuyMedicine()
    {
        if (this.gameState.GetStars() - 10 >= 0)
        {
            // buying medicine
            this.gameState.AddStars(-10);
            this.gameState.AddMedicine(1);
            Popup("You bought medicine!");
        }
        else
        {
            Popup("You don't have enough stars!");
        }
    }

    public void Popup(string popupText)
    {
        backgroundCover.SetActive(true);
        panelPopup.SetActive(true);

        panelPopupText.text = popupText;
    }

    public void ClosePopUp()
    {
        backgroundCover.SetActive(false);
        panelPopup.SetActive(false);
    }
}