const float LOW_TEMP_LIMIT_F = 65.0;
const float HI_TEMP_LIMIT_F = 80.0;
const float WOBBLE_RANGE = 1.0;
const int MIN_RUN_TIME = 1000 * 60 * 2; // 2 minutes

THERMOSTAT_STATE thermostatState = TS_IDLE;
unsigned long int previousThermostatChangeTime = 0;
unsigned long int previousTemperatureReadTime = 0;
double currentTemp = (LOW_TEMP_LIMIT_F + HI_TEMP_LIMIT_F) / 2;

void handleTemperatureState(unsigned long int currentTime)
{
  if (currentTime - previousTemperatureReadTime >= SENSOR_READ_INTERVAL) {
    // currentTemp = digitalRead // read currentTemperature
    previousTemperatureReadTime = currentTime;
  }

  switch (thermostatState)
  {
    case TS_COOLING:
      digitalWrite(HEATER_PIN, OFF);
      digitalWrite(COOLING_PIN, ON);
      
      if ((currentTime - previousThermostatChangeTime >= MIN_RUN_TIME) && (currentTemp < (HI_TEMP_LIMIT_F - WOBBLE_RANGE)))
      {
        setThermostatState(TS_IDLE);
      }
      break;

    case TS_HEATING:
      digitalWrite(HEATER_PIN, ON);
      digitalWrite(COOLING_PIN, OFF);
      
      if ((currentTime - previousThermostatChangeTime >= MIN_RUN_TIME) && (currentTemp > (LOW_TEMP_LIMIT_F + WOBBLE_RANGE)))
      {
        setThermostatState(TS_IDLE);
      }
      break;

    default:
      digitalWrite(HEATER_PIN, OFF);
      digitalWrite(COOLING_PIN, OFF);
      
      if (currentTemp >= HI_TEMP_LIMIT_F && (currentTime - previousThermostatChangeTime >= MIN_RUN_TIME))
      {
        setThermostatState(TS_COOLING);
      }
      else if (currentTemp <= LOW_TEMP_LIMIT_F && (currentTime - previousThermostatChangeTime >= MIN_RUN_TIME))
      {
        setThermostatState(TS_HEATING);
      }
      break;
  }
}

void setThermostatState(THERMOSTAT_STATE state)
{
  thermostatState = state;
  previousThermostatChangeTime = millis();
}
