using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController1 : MonoBehaviour
{
    // Reference to the Menu GameObject
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        // Check if the ESC key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the menu's visibility
            ToggleMenu();
        }
    }

    // Toggle the menu's visibility
    void ToggleMenu()
    {
        // Check if the menu is currently visible
        if (menu.activeSelf)
        {
            // Hide the menu
            menu.SetActive(false);
        }
        else
        {
            // Show the menu
            menu.SetActive(true);
        }
    }
}