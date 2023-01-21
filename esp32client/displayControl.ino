// controls the output of the LCD display
const int MAX_DISPLAY_INTERVAL = 5000;
DISPLAY_STATE displayState = DS_VERSION;
unsigned long int previousDisplayTime = 0;


void handleDisplayState(unsigned long int currentTime)
{

  switch (displayState)
  {
    case DS_TEMPERATURE:
      // display temperature, humidity, and climate state
      if (changeToNextScreen(currentTime))
      {
        setDisplayState(DS_RELAYS);
      }
      break;

    case DS_RELAYS:
      // display the state of the relays
      if (changeToNextScreen(currentTime))
      {
        setDisplayState(DS_UPTIME);
      }
      break;

    case DS_UPTIME:
      // dipslay the uptime of the device in hours
      if (changeToNextScreen(currentTime))
      {
        setDisplayState(DS_VERSION);
      }

    default:
      // display the software version number
      if (changeToNextScreen(currentTime))
      {
        setDisplayState(DS_TEMPERATURE);
      }
      break;
  }
}

bool changeToNextScreen(unsigned long int currentTime)
{
  return (currentTime - previousDisplayTime >= MAX_DISPLAY_INTERVAL);
}

void setDisplayState(DISPLAY_STATE state)
{
  displayState = state;
  previousDisplayTime = millis();
}

void writeToDisplay(char[] line1, char[] line2)
{
  
}
