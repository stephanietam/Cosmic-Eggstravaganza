using UnityEngine;
using UnityEngine.UI;

public class BuyButtonAudioPlay : MonoBehaviour
{
	public ShopItemButtons itemButtons;

	public void OnClick()
	{
		Debug.Log ("here");
		if (this.itemButtons.purchaseFail == true) {
			this.itemButtons.purchaseFail = false;
			Debug.Log ("fail");
			GameObject audioSourceObject = GameObject.FindGameObjectWithTag ("Purchase Fail Audio");
			AudioSource audioSound = audioSourceObject.GetComponent<AudioSource> ();
			audioSound.Play ();
		} else {
			Debug.Log ("success");
			GameObject audioSourceObject = GameObject.FindGameObjectWithTag ("Purchase Audio");
			AudioSource audioSound = audioSourceObject.GetComponent<AudioSource> ();
			audioSound.Play ();
		}
	}
}