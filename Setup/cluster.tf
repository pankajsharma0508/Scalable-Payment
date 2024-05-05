provider "aws" {
  region = "us-east-1"
}


resource "aws_iam_role" "scalable-cluster-eks-role" {
  name = "scalable-cluster-eks-role"

  assume_role_policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Principal": {
        "Service": "eks.amazonaws.com"
      },
      "Action": "sts:AssumeRole"
    }
  ]
}
EOF
}

resource "aws_iam_role_policy_attachment" "scalable-eks-cluster_policy_attachment" {
  policy_arn = "arn:aws:iam::aws:policy/AmazonEKSClusterPolicy"
  role       = aws_iam_role.scalable-cluster-eks-role.name
}

resource "aws_iam_role_policy_attachment" "scalable-eks-service_policy_attachment" {
  policy_arn = "arn:aws:iam::aws:policy/AmazonEKSServicePolicy"
  role       = aws_iam_role.scalable-cluster-eks-role.name
}

resource "aws_eks_cluster" "scalable-cluster" {
  name = "scalable-cluster"
  
  vpc_config {
    subnet_ids = ["subnet-057a7d38f64138d08", "subnet-0369b2597618fe2a7"]
    endpoint_public_access = true
    
  }
  role_arn = aws_iam_role.scalable-cluster-eks-role.arn
}