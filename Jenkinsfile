pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                powershell("-file build.ps1") 
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}