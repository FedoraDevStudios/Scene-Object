#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MochaMoth.SceneObject.SceneObjects
{
	public static class SceneObjectFactory
	{
		const string FACTORY_PATH = "Assets/Mocha Moth";
		const string FACTORY_NAME = "Scene Object Fab.asset";
		static string FactoryAsset => $"{FACTORY_PATH}/{FACTORY_NAME}";

		public static ISceneObject Produce()
		{
			SceneObjectFab fab = (SceneObjectFab)AssetDatabase.LoadAssetAtPath(FactoryAsset, typeof(SceneObjectFab));

			if (fab == null)
			{
				Directory.CreateDirectory(FACTORY_PATH);
				AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SceneObjectFab>(), FactoryAsset);
				Debug.Log($"No Scene Object Fab found at '{FactoryAsset}'. One has been created, however it's locals need to be assigned!");
				return null;
			}

			return fab.SceneObject;
		}
	}
}
#endif
