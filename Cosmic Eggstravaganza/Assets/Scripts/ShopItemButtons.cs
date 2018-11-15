using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButtons : MonoBehaviour
{
    // modes (determines what menu shows up):
    // 0 = none
    // 1 = egg
    // 2 = food
    // 3 - medicine
    private int currentMode;

    public GameObject panel;

    public Text panelTitle;

    public Text panelDescription;

    public Text starsQuantity;

    public Image itemImage;

    public GameState gameState;

    public GameObject panelPopup;

    public Text panelPopupText;

    public GameObject backgroundCover;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
        this.currentMode = 0;

        GameObject gameObject = GameObject.FindGameObjectWithTag("GameState");
        this.gameState = gameObject.GetComponent<GameState>();

        // Hide all the creatures
        List<GameObject> creatures = this.gameState.GetCreatureObjects();
        for (int i = creatures.Count - 1; i >= 0; --i)
        {
            creatures[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (this.currentMode == 1)
        {
            this.starsQuantity.text = "Pets owned: " + this.gameState.creatureCount + "\n" +
                "Stars: " + this.gameState.GetStars();
        }
        else if (this.currentMode==2)
        {
            this.starsQuantity.text = "Owned: " + this.gameState.GetFood() + "\n" +
                "Stars: " + this.gameState.GetStars();
        }
        else if (this.currentMode==3)
        {
            this.starsQuantity.text = "Owned: " + this.gameState.GetMedicine() + "\n" +
                "Stars: " + this.gameState.GetStars();
        }
    }

    private void SetObjects()
    {
        if (this.currentMode == 0)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
            if (this.currentMode == 1)
            {
                Debug.Log("Eggs button clicked");
                panelTitle.text = "Egg";
                panelDescription.text = "Buy a brand new egg!";

                Texture2D tex = Resources.Load<Texture2D>("egg") as Texture2D;
                Sprite sprite = new Sprite();
                sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                itemImage.sprite = sprite;
            }
            else if (this.currentMode == 2)
            {
                Debug.Log("Food button clicked");
                panelTitle.text = "Food";
                panelDescription.text = "Food to feed your pets.";

                Texture2D tex = Resources.Load<Texture2D>("egg") as Texture2D;
                Sprite sprite = new Sprite();
                sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                itemImage.sprite = sprite;
            }
            else if (this.currentMode == 3)
            {
                Debug.Log("Medicine button clicked");
                panelTitle.text = "Medicine";
                panelDescription.text = "Medicine to heal your pets.";

                Texture2D tex = Resources.Load<Texture2D>("egg") as Texture2D;
                Sprite sprite = new Sprite();
                sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                itemImage.sprite = sprite;
            }
        }
    }

    public void ClosePanel()
    {
        this.currentMode = 0;
        SetObjects();
    }

    public void SetEggPanel()
    {
        this.currentMode = 1;
        SetObjects();
    }

    public void SetFoodPanel()
    {
        this.currentMode = 2;
        SetObjects();
    }

    public void SetMedicinePanel()
    {
        this.currentMode = 3;
        SetObjects();
    }

    public void BuyButton()
    {
        if (this.currentMode==1)
        {
            if (this.gameState.GetStars()-50>=0)
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
        else if (this.currentMode==2)
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
        else if (this.currentMode==3)
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