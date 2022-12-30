using MochaMoth.SceneObject.SceneMetadatas;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MochaMoth.SceneObject.SceneObjects.Implementations
{
	[CreateAssetMenu(fileName = "New Scene Object", menuName = "Scene Object/Scene Object")]
	public class ScriptableSceneObject : SerializedScriptableObject, ISceneObject
	{
		[SerializeField, HideLabel, BoxGroup("Scene Object")] ISceneObject _sceneObject;

		public string ScenePath => _sceneObject.ScenePath;

#if UNITY_EDITOR
		public void OnEnable()
		{
			if (_sceneObject == null)
			{
				_sceneObject = SceneObjectFactory.Produce();
				_ = _sceneObject?.ScenePath;
			}
		}
#endif

		public void SetSceneObject(ISceneObject sceneObject) => _sceneObject = sceneObject;
		public T GetMetadata<T>() where T : class, ISceneMetadata => _sceneObject.GetMetadata<T>();
		public ISceneObject Produce()
		{
			Debug.Log("Scriptable Scene Objects are not supposed to be produced by a factory.");
			return null;
		}
	}
}
