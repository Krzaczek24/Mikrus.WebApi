pipeline {
    environment {
        url = 'https://index.docker.io/v1/'
        registry = 'krzaczek24/krzaq.mikrus.webapi'
        registryCredential = 'dockerhub-credentials'
        dockerImage = 'omg'
    }
    agent {
        dockerfile {
            filename 'Dockerfile'
            dir 'Krzaq.Mikrus.WebAPI'
        }
    }
    stages {
        stage('Debug') {
            steps {
                sh "echo '--- OMFG ---'"
                echo dockerImage
                echo '------------'
            }
        }
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        stage('Build') { 
            steps {
                dockerImage = docker.build("${registry}:${env.BUILD_NUMBER}")
            }
        }
        stage('Test') {
            steps {
                sh "docker run --rm ${registry}:${env.BUILD_NUMBER} ./run-tests.sh"
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
