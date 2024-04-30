# Portal

To Create a docker image and test the functinality on local,
Port 8080 is exposed from docker image.

docker build . -t portal_payment
docker run -d -p 5000:8080 portal_payment:latest

You will be able to access the service at localhost:5000
