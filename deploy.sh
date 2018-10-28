#!/usr/bin/bash
spawn heroku login
expect "Email:*"
send $DOCKER_USERNAME
expect "Password:*"
send $DOCKER_PASSWORD
