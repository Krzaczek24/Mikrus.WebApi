pipeline {
    agent { dockerfile true }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') { 
            steps {
                dockerImage = docker.build("krzaczek24/krzaq.mikrus.webapi:${env.BUILD_NUMBER}")
            }
        }
        stage('Test') {
            steps {
                sh 'docker run --rm krzaczek24/krzaq.mikrus.webapi:${env.BUILD_NUMBER} ./run-tests.sh'
            }
        }
        stage('Push') {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com', 'dockerhub-credentials') {
                        dockerImage.push()
                    }
                }
            }
        }
        stage('Deploy') {
            steps {
                sh 'dotnet publish --no-restore -o published'  
            }
            post {
                success {
                    archiveArtifacts 'published/*.*' 
                }
            }
        }
    }
}
