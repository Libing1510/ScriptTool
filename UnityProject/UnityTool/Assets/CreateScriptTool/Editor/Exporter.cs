
using System.IO;
using UnityEditor;
using UnityEngine;
using System;

public class Exporter 
{
    public static string[] assetPathNames = new string[] {"Assets/Plugins","Assets/UnityTools" };



    [MenuItem("Assets/Exprot_UnityTools/SelectionFiles  %k")]
    private static void ExproterClick2()
    {
        string[] ids= Selection.assetGUIDs;
        string[] packageFiles=new string[ids.Length];
        for (int i = 0; i < ids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(ids[i]);
            packageFiles[i] = path;
            Debug.Log( i+" :"+ path);
        }

        AssetDatabase.ExportPackage(packageFiles, Path.Combine(Application.dataPath, "../")+ "/Packages/" + PackageName() + ".unitypackage", ExportPackageOptions.Recurse);

        OpenInFolder(Path.Combine(Application.dataPath, "../") +"/Packages/");
    }


    [MenuItem("Assets/Exprot_UnityTools/All  %e")]
    private static void ExproterClick()
    {
        AssetDatabase.ExportPackage(assetPathNames, Path.Combine(Application.dataPath, "../") + "/Packages/"+ PackageName() + ".unitypackage",ExportPackageOptions.Recurse);
     
        OpenInFolder(Path.Combine(Application.dataPath, "../")+"/Packages/");
    }



    private static string PackageName()
    {
        return  $"UnityPackage_{DateTime.Now.ToString("MMdd_HH")}";
    }

    public static void OpenInFolder(string folderPath)
    {
        Application.OpenURL("file:///" + folderPath);
    }

}
