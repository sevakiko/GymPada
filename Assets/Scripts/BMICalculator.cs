using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BMICalculator : MonoBehaviour
{
    public TMP_InputField heightInput;
    public TMP_InputField weightInput;
    public Button calculateButton;
    public Text bmiText;
    public string plan1Scene;
    public string plan2Scene;
    public string plan3Scene;

    private float height;
    private float weight;
    private float bmi;

    void Start()
    {
        calculateButton.onClick.AddListener(CalculateBMI);
    }

    void CalculateBMI()
    {
        // Get the input values
        height = float.Parse(heightInput.text);
        weight = float.Parse(weightInput.text);

        // Convert height to meters
        height /= 100f;

        // Calculate the BMI
        bmi = weight / (height * height);

        // Display the BMI
        //bmiText.text = "Your BMI is: " + bmi.ToString("F2");
        Debug.Log("Your BMI is: " + bmi);

        // Log the input values
        Debug.Log("Height: " + height);
        Debug.Log("Weight: " + weight);

        // Determine the exercise plan
        if (bmi < 18.5)
        {
            SceneManager.LoadScene(10);
        }
        else if (bmi >= 18.5 && bmi <= 29.9)
        {
            SceneManager.LoadScene(11);
        }
        else if (bmi >= 30)
        {
            SceneManager.LoadScene(12);
        }
    }
}