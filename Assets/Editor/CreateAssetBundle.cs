using UnityEditor;
using System.IO;

public class CreateAssetBundle
{
    [MenuItem("Assets/Build AssetBundles")]
    public static void BuildAllAssetBundles() {
        var assetBundleDirectory = "Assets/AssetBundles";
        if(!Directory.Exists(assetBundleDirectory)) Directory.CreateDirectory(assetBundleDirectory);

        BuildPipeline.BuildAssetBundles(
            assetBundleDirectory, 
            BuildAssetBundleOptions.None, 
            EditorUserBuildSettings.activeBuildTarget);
    }
}
