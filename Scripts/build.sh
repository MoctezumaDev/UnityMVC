#! /bin/sh

project="UnityMVC"

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildWindowsPlayer "$(pwd)/Build/windows/$project.exe" \
  -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildOSXUniversalPlayer "$(pwd)/Build/osx/$project.app" \
  -quit

echo 'Logs from build'
cat $(pwd)/unity.log

mkdir UnityMVC

echo "Attempting to build $project dll"
/Applications/Unity/Unity.app/Contents/Mono/bin/gmcs \
  -target:library \
  -r:/Applications/Unity/Unity.app/Contents/Managed/UnityEngine.dll  \
  -out:$(pwd)/UnityMVC/UnityMVC.dll \
  -debug \
  $(pwd)/Assets/UnityMVC/*.cs

echo "Attempting to create $project unity package"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -exportPackage UnityMVC/ unitymvc.unitypackage
  -quit

ls
