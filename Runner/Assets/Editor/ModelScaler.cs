using UnityEngine;
using System.Collections;
using UnityEditor;

public class ModelScaler : AssetPostprocessor
{
    public void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        modelImporter.globalScale = 1;
    }
}
