# Weather Station

Weather station that logs data and posts to Twitter

## Table Of Contents

* Purpose
* Application Configuration
* API Routes

## Purpose 

Application was created to log weather data for my backyard garden. As a hobby gardener, knowing what the 
weather conditions are impacts what actions, such as watering, that can be done in your garden. Yes
the weather data that is provided by the National Weather Service can be used, but that weather data 
can be significantly different from where those readings take place (usually at airports) and where the 
plants are actuatlly growing (at your house).

## System Requirements

* Sqlite3
* Internet access
* Twitter Developer account
* Raspberry Pi with connected sensor

## Application Configuration

All of the configuration for the application is located in the appsettings.json file. 
Below is a list of each of the properties and what they do.

### DatabaseFile

The path and name of the database file. The application is designed to use 
a SQLite database.

### ReadSensorInterval

How many minutes the application should wait between reading the temperature data. 
The lower the interval, the more readings that will take place.

### RetentionDays

How many days that the observation data should be kept for. To disable deletion 
of old data, set this value to 0.

### ConsumerKey

The Twitter Consumer Key. To get a key, visit the Twitter Developers website.

### ConsumerSecret

The Twitter Consumer Secret. To get a secret, visit the Twitter Developers website.

### AccessToken

The Twitter Access Token. To get a token, visit the Twitter Developers website.

### AccessSecret

The Twitter Access Secret. To get a secret, visit the Twitter Developers website.

## References

* https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
* https://docs.microsoft.com/en-us/ef/core/cli/dotnet
* https://github.com/dotnet/iot/tree/main/src/devices/OneWire