
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateScriptUtil : Editor
{


    static string modlePath = $"{Application.dataPath}/CreateScriptTool";



    [MenuItem("Assets/Create/LB/LBBehaviourCSharp", false,80)]
    public static void CreateNewBehaviourCSharp()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<DoCreateScriptAsset>(),
            GetSelectedPathOrFallback() + "/NewMnonoBehaviourScript.cs", null, modlePath+ "/ScriptTemplates/LBBehaviourScript.cs.txt");
    }

    [MenuItem("Assets/Create/LB/LBCSharp", false, 81)]
    public static void CreateNewCSharp()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, ScriptableObject.CreateInstance<DoCreateScriptAsset>(),
            GetSelectedPathOrFallback() + "/NewScript.cs", null, modlePath + "/ScriptTemplates/LBScript.cs.txt");
    }


    static string GetSelectedPathOrFallback()
    {
        string path = "Assets";

        foreach (UnityEngine.Object  obj in Selection.GetFiltered(typeof(UnityEngine.Object),SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path)&&File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }

        return path;
    }






}
