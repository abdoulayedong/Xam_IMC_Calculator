using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Xam_IMC_Calculator
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Methods
        private double CalculateImc(double height, double weight)
        {
            var imc = Math.Round(weight / Math.Pow(height / 100, 2), 2);
            ImcDetail = GetImcInterpretation(imc);
            return imc;
        }

        private double NextStep(double value)
        {
            return Math.Round(value / STEP) * STEP;
        }

        private string GetImcInterpretation(double imcValue)
        {
            if (imcValue < 18.5)
                return "en insuffisance pondérale (maigreur).";
            else if (imcValue < 25)
                return "en corpulence normale.";
            else if (imcValue < 30)
                return "en surpoids.";
            else if (imcValue < 35)
                return "en obésité modérée.";
            else if (imcValue < 40)
                return "obésité sévère.";
            else
                return "en obésité morbide ou massive.";
        }
        #endregion

        #region Properties
        private const double STEP = 1.0;
        private double _height = 170;
        public double Height
        {
            get { return _height; }
            set
            {
                SetProperty(ref _height, NextStep(value));
                ImcValue = CalculateImc(NextStep(value), Weight);
            }
        }

        private double _weight = 70;
        public double Weight
        {
            get { return _weight; }
            set
            {
                SetProperty(ref _weight, NextStep(value));
                ImcValue = CalculateImc(Height, NextStep(value));
            }
        }

        private double _imcValue;
        public double ImcValue
        {
            get { return _imcValue; }
            set => SetProperty(ref _imcValue, value);
        }

        private string _imcDetail;
        public string ImcDetail
        {
            get { return _imcDetail; }
            set => SetProperty(ref _imcDetail, value);
        }
        #endregion
    }
}
