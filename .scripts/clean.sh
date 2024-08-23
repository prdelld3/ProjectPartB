#!/bin/bash
#To make the .sh file executable
#sudo chmod +x ./clean.sh

#remove recursively all obj and bin directories within the workspace
cd ..
find . -type d \( -name "obj" -o -name "bin" \) -print0 | xargs -0 rm -rf

#remove recursively all csproj.bak
find . -type f -name "*.csproj.bak" -print0 | xargs -0 rm -rf
