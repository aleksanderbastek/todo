#!/bin/bash

echo "Installing node packages (npm install)..."
npm install --slient

echo "Starting application!"
npm run start-in-container
