using UnityEngine;
using UnityEngine.UI;

public class BackgroundAudioScript : MonoBehaviour
{
    public static BackgroundAudioScript Instance;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(transform.gameObject);
        }
    }
}