#!/bin/bash
sh login.sh
docker push registry.heroku.com/bfk-portal/web
heroku container:push web -a bfk-portal
heroku container:release web -a bfk-portal