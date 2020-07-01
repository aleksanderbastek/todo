#!/bin/bash

echo "Installing node packages (npm install)..."
npm install

echo "Starting application!"
npm run start-in-container
