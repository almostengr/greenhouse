const int DAYLIGHT_INTERVAL = 1000 * 60 * 60 * 14; // 14 hours
const int NIGHT_INTERVAL = 1000 * 60 * 60 * 10;  // 10 hours

unsigned long int previousLightStateTime = 0;

void handleLightingState(unsigned long int currentTime)
{
  switch (lightState)
  {
    case L_ON:
      digitalWrite(LIGHT_PIN, ON); // light on

      if (currentTime - previousLightStateTime >= DAYLIGHT_INTERVAL)
      {
        setLightState(L_OFF);
      }
      break;

    default:
      digitalWrite(LIGHT_PIN, OFF); // light off digitalwrite

      if (currentTime - previousLightStateTime >= NIGHT_INTERVAL)
      {
        setLightState(L_ON);
      }
      break;
  }
}

void setLightState(LIGHT_STATE state)
{
  lightState = state;
  previousLightStateTime = millis();
}
