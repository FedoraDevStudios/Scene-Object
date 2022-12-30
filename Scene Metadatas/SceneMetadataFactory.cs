#if UNITY_EDITOR
using MochaMoth.SceneObject.SceneMetadatas;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MochaMoth.SceneObject
{
	public static class SceneMetadataFactory
	{
		const string FACTORY_PATH = "Assets/Mocha Moth";
		const string FACTORY_NAME = "Scene Metadata Fab.asset";
		static string FactoryAsset => $"{FACTORY_PATH}/{FACTORY_NAME}";

		public static ISceneMetadata Produce()
		{
			SceneMetadataFab fab = (SceneMetadataFab)AssetDatabase.LoadAssetAtPath(FactoryAsset, typeof(SceneMetadataFab));

			if (fab == null)
			{
				Directory.CreateDirectory(FACTORY_PATH);
				AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SceneMetadataFab>(), FactoryAsset);
				Debug.Log($"No Scene Metadata Fab found at '{FactoryAsset}'. One has been created, however it's locals need to be assigned!");
				return null;
			}

			return fab.SceneMetadata;
		}
	}
}
#endif