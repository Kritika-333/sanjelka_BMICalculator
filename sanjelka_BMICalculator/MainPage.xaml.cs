namespace sanjelka_BMICalculator;

public partial class MainPage : ContentPage
{
    string gender = "";

    public MainPage()
    {
        InitializeComponent();
    }

    private void MaleTapped(object sender, TappedEventArgs e)
    {
        gender = "Male";

        MaleFrame.BorderColor = Colors.Blue;
        FemaleFrame.BorderColor = Colors.Gray;
    }

    private void FemaleTapped(object sender, TappedEventArgs e)
    {
        gender = "Female";

        FemaleFrame.BorderColor = Colors.Pink;
        MaleFrame.BorderColor = Colors.Gray;
    }

    private void HeightChanged(object sender, ValueChangedEventArgs e)
    {
        HeightLabel.Text = ((int)e.NewValue).ToString();
    }

    private void WeightChanged(object sender, ValueChangedEventArgs e)
    {
        WeightLabel.Text = ((int)e.NewValue).ToString();
    }

    private void CalculateBMI(object sender, EventArgs e)
    {
        double weight = WeightSlider.Value;
        double height = HeightSlider.Value;

        if (height == 0)
        {
            ResultLabel.Text = "Height cannot be zero.";
            return;
        }

        double bmi = (weight * 703) / (height * height);

        string status = "";
        string recommendation = "";

        if (gender == "Male")
        {
            if (bmi < 18.5)
            {
                status = "Underweight";
            }
            else if (bmi < 25)
            {
                status = "Normal";
            }
            else if (bmi < 30)
            {
                status = "Overweight";
            }
            else
            {
                status = "Obese";
            }
        }
        else
        {
            if (bmi < 18)
            {
                status = "Underweight";
            }
            else if (bmi < 24)
            {
                status = "Normal";
            }
            else if (bmi < 29)
            {
                status = "Overweight";
            }
            else
            {
                status = "Obese";
            }
        }

        switch (status)
        {
            case "Underweight":
                recommendation =
                    "Increase calorie intake with nutrient-rich foods and strength training.";
                break;

            case "Normal":
                recommendation =
                    "Maintain a balanced diet and regular exercise.";
                break;

            case "Overweight":
                recommendation =
                    "Reduce processed foods and increase physical activity.";
                break;

            case "Obese":
                recommendation =
                    "Consult a doctor and follow a structured weight-loss plan.";
                break;
        }

        ResultLabel.Text =
            $"Gender: {gender}\n" +
            $"BMI: {bmi:F1}\n" +
            $"Status: {status}\n\n" +
            $"Recommendation:\n{recommendation}";
    }
}