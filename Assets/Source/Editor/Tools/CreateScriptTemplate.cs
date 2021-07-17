using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class CreateScriptTemplate
{

    private const string ACTIVE_FOLDER_METHOD_NAME = "GetActiveFolderPath";
    private const string CREATE_SCRIPT_ASSET_METHOD_NAME = "CreateScriptAssetFromTemplate";
    private const string SHOW_CREATED_ASSET_METHOD_NAME = "ShowCreatedAsset";
    private const string MTG_CLASS_TEMPLATE_PATH = "/EditorDefaultResources/ScriptTemplates/MTG_Class.cs.txt";
    private const string MTG_CLASS_NAME = "NewClass.cs";

    private static MethodInfo _activeFolderMethodInfo = null;
    private static MethodInfo ActiveFolderMethodInfo
    {
        get
        {
            if (_activeFolderMethodInfo != null)
                return _activeFolderMethodInfo;

            _activeFolderMethodInfo = typeof(ProjectWindowUtil).GetMethod(ACTIVE_FOLDER_METHOD_NAME, BindingFlags.Static | BindingFlags.NonPublic);
            
            return _activeFolderMethodInfo;
        }
    }

    private static MethodInfo _createScriptAsset = null;
    private static MethodInfo CreateScriptAssetMethodInfo
    {
        get
        {
            if (_createScriptAsset != null)
                return _createScriptAsset;

            _createScriptAsset = typeof(ProjectWindowUtil).GetMethod(CREATE_SCRIPT_ASSET_METHOD_NAME, BindingFlags.NonPublic | BindingFlags.Static);

            return _createScriptAsset;
        }
    }
    
    private static MethodInfo _showCreatedAsset = null;
    private static MethodInfo ShowCreatedAssetMethodInfo
    {
        get
        {
            if (_showCreatedAsset != null)
                return _showCreatedAsset;

            _showCreatedAsset = typeof(ProjectWindowUtil).GetMethod(SHOW_CREATED_ASSET_METHOD_NAME, BindingFlags.Public | BindingFlags.Static);

            return _showCreatedAsset;
        }
    }

    /// <summary>
    /// Path to the template file for a Plain C# class.
    /// </summary>
    private static string TemplatePathMTGClass => Application.dataPath + MTG_CLASS_TEMPLATE_PATH;

    /// <summary>
    /// Adds a menu item for creating a new plain class file.
    /// </summary>
    [MenuItem("Assets/Create/Script MTG Class", priority = 81)]
    public static void CreateMTGClass()
    {
        if (ActiveFolderMethodInfo == null || CreateScriptAssetMethodInfo == null || ShowCreatedAssetMethodInfo == null)
            return;

        object activeFolderObject = ActiveFolderMethodInfo.Invoke(null, new object[0]);
        string targetDir = activeFolderObject.ToString();

        string pathName = Path.Combine(targetDir ?? throw new InvalidOperationException(), MTG_CLASS_NAME);

        object scriptAssetObject = CreateScriptAssetMethodInfo.Invoke(null, new object[] {pathName, TemplatePathMTGClass});
        /*var scriptAsset = scriptAssetObject as MonoScript;

        Selection.activeObject = scriptAsset;

        Type objectBrowserType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ProjectBrowser");

        foreach (var type in typeof(EditorWindow).Assembly.GetTypes())
        {
            Debug.Log(type.FullName);
        }
        
        var e = new Event {keyCode = KeyCode.F2, type = EventType.KeyDown};
        EditorWindow.GetWindow(objectBrowserType).SendEvent(e);


        //ShowCreatedAssetMethodInfo.Invoke(null, new object[] {assetObject});
        */
    }

    /// <summary>
    /// Validates that the plain class template exists. 
    /// </summary>
    [MenuItem("Assets/Create/Script Template/Class", true, priority = 81)]
    public static bool CreateMTGClassValidate()
    {
        return File.Exists(TemplatePathMTGClass);
    }
    
}



