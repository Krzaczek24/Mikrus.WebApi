pipeline {
	agent any
    environment {
		DOCKERFILE_PATH = ''
		DOCKER_IMAGE = 'krzaczek24/krzaq.mikrus.webapi'
		DOT_NET = '10.0'
    }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
		stage('Build') {
			steps {
                sh "docker build -f Krzaq.Mikrus.WebAPI/Dockerfile -t ${DOCKER_IMAGE}:${BUILD_NUMBER} -t ${DOCKER_IMAGE}:latest ."
            }
		}
        stage('Push') {
            steps {
				withDockerRegistry(credentialsId: 'dockerhub-credentials') {
					sh "docker push ${DOCKER_IMAGE}:${BUILD_NUMBER}"
					sh "docker push ${DOCKER_IMAGE}:latest"
				}
            }
        }
    }
}
