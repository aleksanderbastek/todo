#!/bin/bash

echo "Starting to install node packages (npm install)"
echo "It may take few minutes if packages are not already installed"
echo "Please wait..."
npm install --loglevel verbose

echo "Starting application..."
npm run start-in-container
