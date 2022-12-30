using MochaMoth.SceneObject.SceneObjects.Implementations;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MochaMoth.SceneObject.Editor
{
	public class SceneCreator : OdinEditorWindow
	{
		[MenuItem("Assets/Scene Creator", false, 0)]
		public static void OpenWindow()
		{
			SceneCreator window = GetWindow<SceneCreator>();

			SceneLayout[] layouts = Resources.FindObjectsOfTypeAll<SceneLayout>();

			if (window._layout == null)
			{
				for (int i = 0; i < layouts.Length; i++)
				{
					if (layouts[i].name == "Default Layout")
					{
						window._layout = layouts[i];
						break;
					}
				}
			}

			window.ChangeSceneLocation();

			window.Show();
		}

		[SerializeField, BoxGroup("Location", centerLabel: true), HideLabel, InlineButton("ChangeSceneLocation", "Set to Active")]
		string _sceneLocation;

		[SerializeField, BoxGroup("Scene Name", centerLabel: true), HideLabel]
		string _sceneName = "New Scene";

		[SerializeField, InlineEditor, HideLabel, BoxGroup("Layout", centerLabel: true)]
		SceneLayout _layout;

		public void ChangeSceneLocation()
		{
			if (Selection.activeObject != null)
				_sceneLocation = AssetDatabase.GetAssetPath(Selection.activeObject);
		}

		[Button("Create", buttonSize: ButtonSizes.Large), GUIColor(0.5f, 1f, 0.5f), HorizontalGroup("Buttons")]
		public void CreateScene()
		{
			if (string.IsNullOrWhiteSpace(SceneManager.GetActiveScene().path))
			{
				Debug.Log("Can't create a new scene with an untitled scene loaded.");
				return;
			}

			string sceneFolderPath = string.Format("{0}/{1}", _sceneLocation, _sceneName);

			if (AssetDatabase.IsValidFolder(sceneFolderPath))
				Debug.LogError(string.Format("Scene Path '{0}' already exists!", sceneFolderPath));
			else
			{
				AssetDatabase.CreateFolder(_sceneLocation, _sceneName);

				string scenePath = string.Format("{0}/SE_{1}.unity", sceneFolderPath, _sceneName);
				Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
				SceneManager.SetActiveScene(newScene);
				if (_layout != null)
					for (int i = 0; i < _layout.Objects.Count; i++)
						_ = new GameObject(string.Format(_layout.WrapperText, _layout.Objects[i]));
				_ = EditorSceneManager.SaveScene(newScene, scenePath);

				ScriptableSceneObject newSceneObject = CreateInstance<ScriptableSceneObject>();
				DefaultSceneObject defaultSceneObject = new DefaultSceneObject((SceneAsset)AssetDatabase.LoadAssetAtPath(scenePath, typeof(SceneAsset)));
				newSceneObject.SetSceneObject(defaultSceneObject);
				AssetDatabase.CreateAsset(newSceneObject, string.Format("{0}/SO_{1}.asset", sceneFolderPath, _sceneName));

				AssetDatabase.SaveAssets();
			}
		}

		[Button("Cancel", buttonSize: ButtonSizes.Large), GUIColor(1f, 0.5f, 0.5f), HorizontalGroup("Buttons")]
		public void Cancel()
		{
			//
		}
	}
}