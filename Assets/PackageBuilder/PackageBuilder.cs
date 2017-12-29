 using UnityEngine;
 using UnityEditor;

 public class PackageBuilder{
     static void export() {
         string eportAssetsPath = "Assets/Plugins";
         Debug.Log(eportAssetsPath);
         AssetDatabase.ExportPackage(eportAssetsPath, "unitymvc.unitypackage", ExportPackageOptions.Recurse);
     }
 }