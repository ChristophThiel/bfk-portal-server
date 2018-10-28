#!/usr/bin/expect
spawn heroku login
expect "Email:*"
send $DOCKER_USERNAME
expect "Password:*"
send $DOCKER_PASSWORD
docker push registry.heroku.com/bfk-portal/web
heroku container:push web -a bfk-portal
heroku container:release web -a bfk-portal