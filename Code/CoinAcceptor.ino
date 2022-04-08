#include <Arduino.h>

// variable use to measuer the intervals inbetween impulses
int i=0;
// Number of impulses detected
int impulsCount=0;

void setup() 
{
 // pinMode(2, INPUT_PULLUP); // setups up pin to intake pulses from coin acceptor
 Serial.begin(9600);

 // Interrupt connected to PIN D2 executing IncomingImpuls function when signal goes from HIGH to LOW
 attachInterrupt(0,incomingImpuls, FALLING);
}

void incomingImpuls()
{
  impulsCount=impulsCount+1;
  i=0;
}

void loop() 
{
  i=i+1;

  if (i>=30 and impulsCount==1)
  {
    impulsCount=0;
    Serial.println(1);
  }
}
