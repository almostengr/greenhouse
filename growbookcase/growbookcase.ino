const int ON = 1;
const int OFF = 0;

const int SENSOR_READ_INTERVAL = 1000 * 60 * 5; // 5 minutes
const int LIGHT_TOGGLE_INTERVAL = 1000 * 60 * 12; // 12 hours
const int FAN_TOGGLE_INTERVAL = 1000  * 60 * 30: // 30 minutes

const int LIGHT_PIN = 4;
const int FAN_PIN = 5;
const int HEATER_PIN = 6;
const int COOLING_PIN = 7;

enum LIGHTING
{
  LIGHT_ON,
  LIGHT_OFF,
};

enum WATER_PUMP
{
  PUMP_ON,
  PUMP_OFF,
};

enum THERMOSTAT_STATE {
  TS_COOLING,
  TS_HEATING,
  TS_IDLE
};

enum DISPLAY_STATE {
  DS_VERSION,
  DS_TEMPERATURE,
  DS_RELAYS,  
  DS_UPTIME,
};

enum FAN_STATE {
    FAN_ON,
    FAN_OFF,
};

void setup()
{
  pinMode(LIGHT_PIN, OUTPUT);
  pinMode(FAN_PIN, OUTPUT);
  pinMode(HEATER_PIN, OUTPUT);
  pinMode(COOLING_PIN, OUTPUT);
}

LIGHT_STATE lightState = L_ON;

unsigned long int previousFanTime;

void loop()
{
  unsigned long int currentTime = millis();
  
  previousFanTime = handleFan(previousFanTime, currentTime);
  previousLightTime = handleLighting(previousLightingTime, currentTime);
  previousWaterTime = handleWatering(previousWaterTime, currentTime);
}


long handleFan(long previousTime, long currentTime)
{
  return currentTime;
}

long handleLighting(long previousTime, long currentTime)
{
  return currentTime;
}

long handleWatering(long previousTime, long currentTime)
{
  
  return currentTime;
}