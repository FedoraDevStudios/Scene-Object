using UnityEngine;

namespace MochaMoth.SceneObject.SceneReferences
{
	public interface ISceneReference
	{
		bool IsValidSceneAsset(Object sceneAsset);
		void OnBeforeSerialize(Object sceneAsset);
		void OnAfterDeserialize(Object sceneAsset);
		string GetScenePath(Object sceneAsset);
		void SetScenePath(string value);
		ISceneReference Produce();
	}
}
