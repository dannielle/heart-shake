#include <Wire.h>
#include "BMA250.h"

BMA250 accel;
int xPrime;
int yPrime;
int zPrime;

int tiltCount;
int punchCount;

int PUNCH_INT = 1;
int SHAKE_INT = 2;

void setup() {
  Serial.begin(9600);
  accel.begin(BMA250_range_2g, BMA250_update_time_64ms);//This sets up the BMA250 accelerometer
  accel.read();
  calibrate();
  tiltCount = 0;
  punchCount = 0;
}

void loop() {
  accel.read();
  bool isTilted = checkForTilt();

  if (isTilted){
    tiltCount++;
    calibrate();
  }

  bool isPunched = checkForPunch(tiltCount);
  if (isPunched){
    Serial.write(PUNCH_INT);
    Serial.flush();
    delay(20);
    punchCount++;
    tiltCount = 0;
  }
}

void calibrate() {
  xPrime = accel.X;
  yPrime = accel.Y;
  zPrime = accel.Z;
}

bool checkForTilt() {
  bool tilted = false;
  int xTol = 100;
  int yTol = 100;
  int zTol = 100;
  
  if (accel.X > (xPrime + xTol) || accel.X < (xPrime - xTol) ){
    tilted=true;
  }

  if (accel.Y > (yPrime + yTol) || accel.Y < (yPrime - yTol) ){
    tilted = true;
  }

  if (accel.Z > (zPrime + zTol) || accel.Z < (zPrime - zTol) ) {
    tilted = true;
  }
  return tilted;
}

bool checkForPunch(int tiltCount){
  if (tiltCount > 4) {
    return true;
  }
  return false;
}

bool checkForShaken(int punchCount){
  if (punchCount > 2) {
    return true;
  }
  return false;
}

