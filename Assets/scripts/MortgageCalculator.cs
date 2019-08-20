using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MortgageCalculator : MonoBehaviour
{

    public TMP_InputField housePrice;
    public TMP_InputField downpayment;
    public TMP_InputField interestRate;
    public TMP_InputField amortization;
    public TextMeshProUGUI result;


    public void CalculateMonthlyPayment()
    {

        float _housePrice = Convert.ToSingle(housePrice.text);
        float _downpayment = Convert.ToSingle(downpayment.text);
        float _interest = Convert.ToSingle(interestRate.text)/100;
        float _amortization = Convert.ToSingle(amortization.text)/12;
        //result.text = GetMonthly(_housePrice).ToString();
        result.text = GetMortgage(_housePrice, _interest, _amortization,_downpayment).ToString("#.##");


    }

    private float GetMonthly(float housePrice)
    {
        return(housePrice / 12);
    }


    public double GetMortgage(float _housePrice, float _interest, float _amortization, float _downpayment)
    {
        _housePrice = _housePrice - _downpayment;
        double t = Math.Pow(1 + _interest, _amortization);
        double monthlyPayment = (_housePrice) * ( (_interest * t) / (t - 1) );
        return monthlyPayment;

    }
}
