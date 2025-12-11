pipeline {
    environment {
        url = 'https://index.docker.io/v1/'
        registry = 'krzaczek24/krzaq.mikrus.webapi:' + env.BUILD_NUMBER
        registryCredential = 'dockerhub-credentials'
        dockerImage = ''
    }
    agent { dockerfile true }
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') { 
            steps {
                dockerImage = docker.build(registry)
            }
        }
        stage('Test') {
            steps {
                sh 'docker run --rm ${registry} ./run-tests.sh'
            }
        }
        stage('Push') {
            steps {
                script {
                    docker.withRegistry(url, registryCredential) {
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
