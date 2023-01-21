const int FAN_CYCLE_INTERVAL = 1000 * 60 * 30; // 30 minutes

FAN_STATE fanState = F_OFF;
unsigned long int previousFanTime = 0;

void handleFanState(unsigned long int currentTime)
{
  switch (fanState)
  {
    case F_ON:
      digitalWrite(FAN_PIN, ON);
      if (currentTime - previousFanTime >= FAN_CYCLE_INTERVAL)
      {
        setFanState(F_OFF);
      }
      break;

    default:
      digitalWrite(FAN_PIN, OFF);
      if (currentTime - previousFanTime >= FAN_CYCLE_INTERVAL && lightState == L_ON)
      {
        setFanState(F_ON);
      }
      break;
  }
}

void setFanState(FAN_STATE state)
{
  fanState = state;
  previousFanTime = millis();
}
