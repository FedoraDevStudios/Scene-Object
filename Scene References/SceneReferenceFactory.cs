#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace MochaMoth.SceneObject.SceneReferences
{
	public static class SceneReferenceFactory
	{
		const string FACTORY_PATH = "Assets/Mocha Moth";
		const string FACTORY_NAME = "Scene Reference Fab.asset";
		static string FactoryAsset => $"{FACTORY_PATH}/{FACTORY_NAME}";

		public static ISceneReference Produce()
		{
			SceneReferenceFab fab = (SceneReferenceFab)AssetDatabase.LoadAssetAtPath(FactoryAsset, typeof(SceneReferenceFab));

			if (fab == null)
			{
				Directory.CreateDirectory(FACTORY_PATH);
				AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SceneReferenceFab>(), FactoryAsset);
				Debug.Log($"No Scene Reference Fab found at '{FactoryAsset}'. One has been created, however it's locals need to be assigned!");
				return null;
			}

			return fab.SceneReference;
		}
	}
}
#endif
