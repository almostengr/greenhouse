const int ON = 1;
const int OFF = 0;

const int SENSOR_READ_INTERVAL = 1000 * 60 * 5; // 5 minutes

const int LIGHT_PIN = 4;
const int FAN_PIN = 5;
const int HEATER_PIN = 6;
const int COOLING_PIN = 7;

enum FAN_STATE
{
  F_ON,
  F_OFF,
};

enum LIGHT_STATE
{
  L_ON,
  L_OFF,
};

enum PUMP_STATE
{
  P_ON,
  P_OFF,
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

void setup()
{
  pinMode(LIGHT_PIN, OUTPUT);
  pinMode(FAN_PIN, OUTPUT);
  pinMode(HEATER_PIN, OUTPUT);
  pinMode(COOLING_PIN, OUTPUT);
}

LIGHT_STATE lightState = L_ON;

void loop()
{
  unsigned long int currentTime = millis();
  
  handleLightingState(currentTime);
  handleFanState(currentTime);
  handleTemperatureState(currentTime);
}
