using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MochaMoth.SceneObject.Implementations
{
	public partial class SceneReference
    {
#if UNITY_EDITOR
		Object _sceneAsset;

		public bool IsValidSceneAsset(Object sceneAsset)
		{
			if (sceneAsset == null)
				return false;
			return sceneAsset.GetType().Equals(typeof(SceneAsset));
		}

		public void OnBeforeSerialize(Object sceneAsset)
		{
			HandleBeforeSerialize(sceneAsset);
		}

		public void OnAfterDeserialize(Object sceneAsset)
		{
			_sceneAsset = sceneAsset;
			EditorApplication.update += HandleAfterDeserialize;
		}

		public string GetScenePath(Object sceneAsset)
		{
			return GetScenePathFromAsset(sceneAsset);
		}

		public void SetScenePath(string value)
		{
			_scenePath = value;
		}

		private SceneAsset GetSceneAssetFromPath()
		{
			if (string.IsNullOrEmpty(_scenePath))
				return null;
			return AssetDatabase.LoadAssetAtPath<SceneAsset>(_scenePath);
		}

		private string GetScenePathFromAsset(Object sceneAsset)
		{
			if (sceneAsset == null)
				return string.Empty;
			return AssetDatabase.GetAssetPath(sceneAsset);
		}

		private void HandleBeforeSerialize(Object sceneAsset)
		{
			if (!IsValidSceneAsset(sceneAsset) && !string.IsNullOrEmpty(_scenePath))
			{
				sceneAsset = GetSceneAssetFromPath();
				if (sceneAsset == null)
					_scenePath = string.Empty;

				UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
			}
			else
			{
				_scenePath = GetScenePathFromAsset(sceneAsset);
			}
		}

		private void HandleAfterDeserialize()
		{
			EditorApplication.update -= HandleAfterDeserialize;
			if (IsValidSceneAsset(_sceneAsset))
				return;

			if (!string.IsNullOrEmpty(_scenePath))
			{
				_sceneAsset = GetSceneAssetFromPath();
				if (_sceneAsset == null)
					_scenePath = string.Empty;

				if (Application.isPlaying == false)
					UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
			}
		}
#endif
	}
}
