using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuUI; // Assign your menu UI GameObject in the Inspector

    private bool isMenuOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menuUI.SetActive(isMenuOpen);
    }
}