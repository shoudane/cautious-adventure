using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/** =========================================================

 Said Houdane

 Operating System: Windows 7

 Microsoft Visual Studio 2015 Community

 CIS 169

 Name Of homework Assignment: Unit 5 Hospital Charges

 Program Description: this program ask for input from user and calculate the charges for days stayed in the hospital,
    medication, lab fees, surgical and other misc charges.

 Academic Honesty:

 I attest that this is my original work.

 I have not used unauthorized source code, either modified or unmodified.

 I have not given other fellow student(s) access to my program.

=========================================================== **/

namespace HospitalCharges
{
    public partial class hospitalCharges : Form
    {
        public hospitalCharges()
        {
            InitializeComponent();
        }

        // These methods accept the number of days at the hospital
        // and medical charges as arguments and return the
        // equivalent total of charges.
        private double CalcStayCharges(double days)
        {
            return days * 350.0;
        }

        private double CalcMiscCharges(double medical, double surgical, double lab, double rehab)
        {
            return (medical + surgical + lab + rehab);
        }

        private double CalcTotalCharges(double days, double medical, double surgical, double lab, double rehab)
        {
            return CalcStayCharges(days) + CalcMiscCharges(medical, surgical, lab, rehab);
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Variables to hold the number of days spent at the hospital, amount of medication, surgical, lab and rehab charges. 
            double days;
            double stayTotal;
            double medical;
            double surgical;
            double lab;
            double rehab;
            double totalFees;
            double totalCharges;

            // Get the number of days.
            if (!double.TryParse(hospitalDaysTextBox.Text, out days) || days <= 0.0)
            {
                MessageBox.Show("Length of stay (days) is invalid. Please enter a valid number");
                hospitalDaysTextBox.Focus();
                return;

            }

            // Get the medication charges

            if (!double.TryParse(medicationChargesTextBox.Text, out medical) || medical < 0.0)
            {
                MessageBox.Show("Medication charges are invalid. Please enter a valid number");
                medicationChargesTextBox.Focus();
                return;
            }

            // Get the surgical charges

            if (!double.TryParse(surgicalChargesTextBox.Text, out surgical) || surgical < 0.0)
            {
                MessageBox.Show("Surgical charges are invalid. Please enter a valid number");
                surgicalChargesTextBox.Focus();
                return;
            }

            // Get the lab fees

            if (!double.TryParse(labFeesTextBox.Text, out lab) || lab < 0.0)
            {
                MessageBox.Show("Lab fees are invalid. Please enter a valid number");
                labFeesTextBox.Focus();
                return;
            }

            // Get the physical rehabilitation charges

            if (!double.TryParse(physicalRehabTextBox.Text, out rehab) || rehab < 0.0)
            {
                MessageBox.Show("Phycial rehabilitation charges are invalid. Please enter a valid number");
                physicalRehabTextBox.Focus();
                return;
            }

            stayTotal = days * 350.0;
            stayFeesLabel.Text = stayTotal.ToString("n2");

            // Calculate the total charges.
            totalCharges = CalcTotalCharges(days, medical, surgical, lab, rehab);
            // Display the total charges.
            totalLabel.Text = totalCharges.ToString("n2");


            // Calculate Misc fees.
            totalFees = CalcMiscCharges(medical, surgical, lab, rehab);
            // Display the total Fees.
            miscLabel.Text = totalFees.ToString("n2");

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close this form.
            this.Close();
        }
    }
}