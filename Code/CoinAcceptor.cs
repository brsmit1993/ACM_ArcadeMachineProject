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

    // This text view needs to be set inside the unity editor after this script is put on an empty game object!
    public Text currentBalanceText;

    // This SerialPort is where the line of communication begins. Where you see "COM#" (# likely 1-9) can be found under windows device manager via Ports(COM & LPT)
    SerialPort sp = new SerialPort("COM6", 9600);
    
    void Start()
    {
        sp.Open(); // this opens the port
        sp.ReadTimeout = 1; // I can't remember what this does but unless you know just leave it.  I believe it prevents freezing
    }

    // Update is called once per frame
    void Update()
    {
        // stops error if sp is not open
        if(sp.IsOpen)
        {

            try
            {
                //currently the coin acceptor is set up to send a signal to the microcontroller that then outputs "1" to the SP to be read in here if a quarter is inserted
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
