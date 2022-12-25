using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MochaMoth.SceneObject.Implementations
{
	public class InstantLoader : ISceneLoader
	{
		[SerializeField, BoxGroup("Loading Screen")] bool _showLoadingScreen;
		[SerializeField, ShowIf(nameof(_showLoadingScreen)), BoxGroup("Loading Screen")] ISceneObject _loadingScene;

		LoadingBarBehaviour _loadingBar = null;

		public IEnumerator LoadAsync(ISceneObject sceneObject)
		{
			if (_showLoadingScreen)
				yield return LoadWithLoadingScreenAsync(sceneObject);
			else
				yield return LoadWithoutLoadingScreen(sceneObject);

			_ = SceneManager.SetActiveScene(SceneManager.GetSceneByPath(sceneObject.ScenePath));
		}

		IEnumerator LoadWithLoadingScreenAsync(ISceneObject sceneObject)
		{
			yield return LoadLoadingScene();
			yield return LoadWithoutLoadingScreen(sceneObject);
			yield return UnloadLoadingScreen();
		}

		IEnumerator LoadWithoutLoadingScreen(ISceneObject sceneObject)
		{
			yield return UnloadActiveScene();
			yield return LoadTargetScene(sceneObject);
		}

		IEnumerator LoadLoadingScene()
		{
			AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(_loadingScene.ScenePath, LoadSceneMode.Additive);
			while (!loadingOperation.isDone)
				yield return null;

			_loadingBar = Object.FindObjectOfType<LoadingBarBehaviour>();
		}

		IEnumerator UnloadActiveScene()
		{
			AsyncOperation unloadingOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
			while (!unloadingOperation.isDone)
			{
				if (_loadingBar != null)
					_loadingBar.SetSliderValue(unloadingOperation.progress / 2f);
				yield return null;
			}
		}

		IEnumerator LoadTargetScene(ISceneObject sceneObject)
		{
			AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(sceneObject.ScenePath, LoadSceneMode.Additive);
			while (!loadingOperation.isDone)
			{
				if (_loadingBar != null)
					_loadingBar.SetSliderValue((loadingOperation.progress / 2f) + 0.5f);
				yield return null;
			}
		}

		IEnumerator UnloadLoadingScreen()
		{
			AsyncOperation unloadingOperation = SceneManager.UnloadSceneAsync(_loadingScene.ScenePath);
			while (!unloadingOperation.isDone)
				yield return null;

			_loadingBar = null;
		}
	}
}
