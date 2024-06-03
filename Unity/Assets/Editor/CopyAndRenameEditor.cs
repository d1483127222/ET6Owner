using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CopyAndRenameEditor
{
    static string [] sourcePath =
    {
        "../Unity/Temp/Bin/Debug/Unity.Mono/mscorlib.dll",
        "../Unity/Temp/Bin/Debug/Unity.Mono/System.Core.dll",
        "../Unity/Temp/Bin/Debug/Unity.Mono/System.dll",
        "../Unity/Temp/Bin/Debug/Unity.Mono/Unity.Mono.dll",
        "../Unity/Temp/Bin/Debug/Unity.Mono/Unity.ThirdParty.dll",
        
    };
    static string[] destinationPath =
    {
        "/Bundles/Code/mscorlib.dll.bytes",
        "/Bundles/Code/System.Core.dll.bytes",
        "/Bundles/Code/System.dll.bytes",
        "/Bundles/Code/Unity.Mono.dll.bytes",
        "/Bundles/Code/Unity.ThirdParty.dll.bytes",
    };
    
    [MenuItem("Tools/CopyDll")]
    public static void CopyAndRenameFile1()
    {
        Debug.Log("拷贝开始" );
        
        CopyAndRenameFile(sourcePath,destinationPath);
        Debug.Log("拷贝dll完成");
    }
    
    
    public static void CopyAndRenameFile(string[] sourceFilePath, string[] destinationFilePath)
    {
        
        
        for (int i = 0; i < sourceFilePath.Length; i++)
        {
            EditorUtility.DisplayProgressBar("Simple Progress Bar", "Shows a progress bar for the given seconds", i+1 / sourceFilePath.Length);
            // 确保目标路径存在
            string destinationDirectory = Path.GetDirectoryName(Application.dataPath + "/" + destinationFilePath[i]);
            //Debug.Log("目标目录" + destinationDirectory );
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            string filePath = Application.dataPath + "/" + destinationFilePath[i];
            //Debug.Log("目标路径" + filePath );
            if (File.Exists(filePath))
            {
                File.Delete(filePath); // 删除文件
                Debug.Log("File deleted successfully");
            }
            // 复制并改名文件
            File.Copy( sourceFilePath[i], Application.dataPath + "/" +destinationFilePath[i], true); // true表示如果目标文件存在，则覆盖它
        }
        EditorUtility.ClearProgressBar();
        
    }
    
    //CopyAndRenameFile(sourcePath, destinationPath);
}
