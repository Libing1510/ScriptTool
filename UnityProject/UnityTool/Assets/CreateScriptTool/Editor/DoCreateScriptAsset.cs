
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class DoCreateScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {

        UnityEngine.Object obj = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(obj);

    }

    internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName,string resourceFile)
    {
        string fullPath = Path.GetFullPath(pathName);
        Debug.Log(pathName + "***" + fullPath);
        Debug.Log(resourceFile);
        Debug.Log(File.Exists(resourceFile));
        StreamReader sr = new StreamReader(resourceFile);
        string text = sr.ReadToEnd();
        sr.Close();
        sr.Dispose();
        Debug.Log(text);
        //TODO:脚本内容处理

        string fileNameWithOutExtension = Path.GetFileNameWithoutExtension(pathName);
        string fileAssetPath =Path.GetDirectoryName( pathName);
        fileAssetPath = fileAssetPath.Replace("Assets\\", " ");
        fileAssetPath = fileAssetPath.Replace("\\", ".");
        text = Regex.Replace(text, "#SCRIPTNAME#", fileNameWithOutExtension);
        text = Regex.Replace(text, "#DATE#", System.DateTime.Now.ToString("yyyy-MM-dd"));
        text = Regex.Replace(text, "#NAMESPACE#", fileAssetPath);

        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOninvalidBytes = false;

        System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOninvalidBytes);

        bool append = false;
        StreamWriter sw = new StreamWriter(fullPath, append, encoding);
        sw.Write(text);
        sw.Close();
        sw.Dispose();

        AssetDatabase.ImportAsset(pathName);
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));








    }




}
