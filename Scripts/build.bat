rmdir /s /q ..\Assets\Plugins
mkdir ..\Assets\Plugins

CALL "C:\Program Files\Unity\Editor\Data\Mono\bin\gmcs.bat" ^
  -r:"C:\Program Files\Unity\Editor\Data\Managed\UnityEngine.dll" ^
  -target:library -out:..\Assets\Plugins\UnityMVC.dll ^
  -debug ^
  ..\Assets\UnityMVC\*.cs

CALL "C:\Program Files\Unity\Editor\Unity.exe" ^
  -batchmode ^
  -nographics ^
  -silent-crashes ^
  -logFile ..\unity.log ^
  -projectPath %~dp0..\ ^
  -executeMethod PackageBuilder.export ^
  -quit ^

EXIT 0
