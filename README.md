# Portal

To Create a docker image and test the functinality on local,
Port 8080 is exposed from docker image.

docker build . -t scalable-payment
docker run -d -p 5000:8080 pank05081985/scalable-payment

You will be able to access the service at localhost:5000


To Deploy service on Minikube on local machine,

#Initialize
minikube start

#dashboard
minikube dashboard

# deploy 
kubectl apply -f Deployment.yaml

# delete deployment
kubectl delete -n default deployment payment-service

# add a node port service for testing purpose on local.
kubectl port-forward service/payment-service 5000:5000



