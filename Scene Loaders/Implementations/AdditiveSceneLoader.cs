using MochaMoth.SceneObject.SceneObjects;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MochaMoth.SceneObject.SceneLoaders.Implementations
{
	public class AdditiveSceneLoader : ISceneLoader
	{
		[SerializeField] bool _markNewScenesAsActive = false;

		public IEnumerator LoadAsync(ISceneObject sceneObject)
		{
			AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneObject.ScenePath, LoadSceneMode.Additive);
			while (!loadOperation.isDone)
				yield return null;

			if (_markNewScenesAsActive)
				_ = SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneObject.ScenePath));
		}
	}
}
