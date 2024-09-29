using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BMICalculator : MonoBehaviour
{
    public TMP_InputField heightInput;
    public TMP_InputField weightInput;
    public Button calculateButton;
    public Text bmiText;
    public GameObject plan1;
    public GameObject plan2;
    public GameObject plan3;
    public GameObject plan4;
    public GameObject plan5;

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
            plan1.SetActive(true);
            plan2.SetActive(false);
            plan3.SetActive(false);
        }
        else if (bmi >= 18.5 && bmi <= 29.9)
        {
            plan1.SetActive(false);
            plan2.SetActive(true);
            plan3.SetActive(false);
        }
        else if (bmi >= 30 )
        {
            plan1.SetActive(false);
            plan2.SetActive(false);
            plan3.SetActive(true);
        }
        
        
    }
}