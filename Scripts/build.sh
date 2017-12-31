#! /bin/sh

project="UnityMVC"

error_code=0

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

echo "Running $project test"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
	-batchmode \
	-nographics \
	-silent-crashes \
	-logFile $(pwd)/unity.log \
	-projectPath $(pwd) \
	-runEditorTests \
	-editorTestsResultFile $(pwd)/test.xml \
	-quit

if [ $? = 0 ] ; then
  echo "Created dll successfully."
  ls $(pwd)/Assets/Plugins
  error_code=0
else
  echo "Creating dll failed. Exited with $?."
  error_code=1
  cat $(pwd)/unity.log
  exit $error_code
fi

echo "Unit test logs"
cat $(pwd)/test.xml

mkdir Assets/Plugins

echo "Attempting to build $project dll"
/Applications/Unity/Unity.app/Contents/Mono/bin/gmcs \
  -target:library \
  -r:/Applications/Unity/Unity.app/Contents/Managed/UnityEngine.dll  \
  -out:$(pwd)/Assets/Plugins/UnityMVC.dll \
  -debug \
  $(pwd)/Assets/UnityMVC/*.cs

if [ $? = 0 ] ; then
  echo "Created dll successfully."
  ls $(pwd)/Assets/Plugins
  error_code=0
else
  echo "Creating dll failed. Exited with $?."
  error_code=1
  cat $(pwd)/unity.log
  exit $error_code
fi

echo "Attempting to create $project unity package"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -executeMethod PackageBuilder.export \
  -quit \

if [ $? = 0 ] ; then
  echo "Created package successfully."
  error_code=0
else
  echo "Creating package failed. Exited with $?."
  error_code=1
  cat $(pwd)/unity.log
fi

echo "List project files"
ls

echo "Finishing with code $error_code"
exit $error_code
