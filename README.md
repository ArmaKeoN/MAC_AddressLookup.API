# MAC_AddressLookup.API

Steps to build and run in docker:

1) Build the docker image and tag it with a descriptive name

docker build -t macaddresslookupapi .

2) Run in interactive mode as you'll get a runtime error (no fault of my own) due to complications with .NET Core + Docker
  - Console.ReadLine does not block (thread) while running in Docker

docker run -i macaddresslookupapi
