pipeline {
    agent { dockerfile true }
    stages {
        stage('Build') { 
            steps {
                sh 'dotnet restore' 
                sh 'dotnet build --no-restore' 
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --no-build --no-restore --collect "XPlat Code Coverage"' 
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
