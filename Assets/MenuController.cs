using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button playButton;
    public Button howToPlayButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        howToPlayButton.onClick.AddListener(ShowHowToPlay);
    }

    void PlayGame()
    {
        // Load your game scene or start the game logic here
        Debug.Log("Play button clicked!");
    }

    void ShowHowToPlay()
    {
        // Load your "How to play" scene or display instructions here
        Debug.Log("How to play button clicked!");
    }
}