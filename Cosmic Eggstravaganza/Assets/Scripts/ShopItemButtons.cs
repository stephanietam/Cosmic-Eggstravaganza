﻿using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButtons : MonoBehaviour
{
    public Text starsQuantity;

    public GameState gameState;

    public GameObject popupPanel;

    public Text popupText;

    public Button popupButton;

    public GameObject popupBG;

    public Text ownEggs;

    public Text ownMedicine;

    public Text ownFood;

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

        this.ownEggs.text = "Pet Count: " + this.gameState.creatureCount;
        this.ownFood.text = "Own: " + this.gameState.GetFood();
        this.ownMedicine.text = "Own: " + this.gameState.GetMedicine();
    }

    private void Update()
    {
        this.starsQuantity.text = "Stars: " + this.gameState.GetStars().ToString();
    }

    public void BuyEgg()
    {
        if (this.gameState.GetStars() - 50 >= 0)
        {
            // buying egg
            this.gameState.AddStars(-50);

            // Create gameobject
            this.gameState.CreateCreature();
            this.ownEggs.text = "Pet count: " + this.gameState.creatureCount;
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
            this.ownFood.text = "Own: " + this.gameState.GetFood().ToString();
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
            this.ownMedicine.text = "Own: " + this.gameState.GetMedicine().ToString();
            Popup("You bought medicine!");
        }
        else
        {
            Popup("You don't have enough stars!");
        }
    }

    private void Popup(string message)
    {
        this.popupPanel.SetActive(true);
        this.popupBG.SetActive(true);
        this.popupText.text = message;
    }

    public void ClosePopup()
    {
        this.popupPanel.SetActive(false);
        this.popupBG.SetActive(false);
    }
}