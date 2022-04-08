/***************************
 *
 *  !!!VERY IMPORTANT NOTE!!!
 *  
 *  This code was originally created and compiled in Unity 2019.2.0f1
 *  
 *  If you choose to use a different version be aware that this maybe break the code currently in use!
 *
 ***************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System;

public class CoinAcceptor : MonoBehaviour
{
    private int currentBalance = 0;

   
    public Text currentBalanceText;

    SerialPort sp = new SerialPort("COM6", 9600);
    
    void Start()
    {
        sp.Open(); 
        sp.ReadTimeout = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if(sp.IsOpen)
        {
            try
            {
                if (sp.ReadLine().Equals("1")) 
                {
                    currentBalance = currentBalance + 25;
            
                    string bal = string.Format("{0:#.00}", Convert.ToDecimal(currentBalance) / 100);
  
                    currentBalanceText.text = "Current Balance \n" + bal;
                }
            }
            catch(System.Exception)
            {
		
            }
        }
    }
}
