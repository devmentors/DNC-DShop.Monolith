#!/bin/bash
DOCKER_ENV=''
DOCKER_TAG=''

case "$TRAVIS_BRANCH" in
  "master")
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  "develop")
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker build -f ./src/DShop.Monolith.Api/Dockerfile.$DOCKER_ENV -t dshop.monolith.api:$DOCKER_TAG ./src/DShop.Monolith.Api
docker tag dshop.monolith.api:$DOCKER_TAG $DOCKER_USERNAME/dshop.monolith.api:$DOCKER_TAG
docker push $DOCKER_USERNAME/dshop.monolith.api:$DOCKER_TAG