pipeline {
    environment {
		DOT_NET = '10.0'
        REGISTRY = 'krzaczek24/krzaq.mikrus.webapi'
    }
	agent {
		docker {
			image "mcr.microsoft.com/dotnet/sdk:${env.DOT_NET}"
			registryUrl 'https://index.docker.io/v1/'
			registryCredentialsId = 'dockerhub-credentials'
		}
	}
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Docker') {
            steps {
                def image = docker.build("${env.REGISTRY}:${env.BUILD_NUMBER}")
				image.push()
            }
        }
        stage('Deploy') {
            
        }
    }
}
