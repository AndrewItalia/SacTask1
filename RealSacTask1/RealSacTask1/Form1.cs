using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealSacTask1
{
    public partial class Form1 : Form
    {
        float total;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            float purchasedValue = (float)numPurchasedPrice.Value;
            int age = (int)numAge.Value;
            // if the age of amount spent is = 0 a error message will pop up 
            if (purchasedValue == 0.0 | age == 0)
            {
                lblOutput.Text = "Please enter a valid price or year";
            }
            else
            {
                // calls functions to calculate the total
                float currentValue = CalculateCurrentValue(purchasedValue, age);
                total += currentValue;
                lblOutput.Text = $"The item is worth ${currentValue}\nThe collection so far is worth ${total}";
            }
            resetInputs();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Calls the reset function
            resetInputs();
            lblOutput.Text = "";
        }
        private float CalculateCurrentValue(float purchasedValue, int age)
        {
            // Formula for depreciation the book will be worth 20% less as each year passes
            float depreciation = purchasedValue * 0.2f * age;
            // if depreciatation is greater than the purchase price then the value is 0
            if (depreciation > purchasedValue) return 0f;
            return purchasedValue - depreciation;
        }


        private void resetInputs()
        {
            // Creates Reset function when "End the quote" is pressed
            // sets the age to 0 and the purchased price to 0
            numAge.Value = 0;
            numPurchasedPrice.Value = 0;
        }


    }
}
