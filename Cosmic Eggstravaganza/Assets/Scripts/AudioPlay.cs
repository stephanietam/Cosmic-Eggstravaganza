using UnityEngine;
using UnityEngine.UI;

public class AudioPlay : MonoBehaviour
{
    public AudioSource audioSound;

    public void OnClick()
    {
        audioSound.Play();
    }
}