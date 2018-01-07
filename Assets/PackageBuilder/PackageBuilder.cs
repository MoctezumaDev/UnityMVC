//  UnityMVC
//  
//  Copyright (C) 2016-2018 Leon Moctezuma <leon.moctezuma@gmail.com>
//  
//  This software may be modified and distributed under the terms
//  of the MIT license.  See the LICENSE file for details.

using UnityEditor;
using UnityEngine;

public class PackageBuilder
{
    static void Export()
    {
        string eportAssetsPath = "Assets/Plugins";
        Debug.Log(eportAssetsPath);
        AssetDatabase.ExportPackage(eportAssetsPath, "unitymvc.unitypackage", ExportPackageOptions.Recurse);
    }
}