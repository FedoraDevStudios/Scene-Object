using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.SceneObject.Implementations
{
    [CreateAssetMenu(fileName = "New Scene Object", menuName = "Scene Object/Scene Object")]
    public class ScriptableSceneObject : SerializedScriptableObject, ISceneObject
    {
        [SerializeField, HideLabel, BoxGroup("Scene Object")] ISceneObject _sceneObject;

        public string ScenePath => _sceneObject.ScenePath;

		public void SetSceneObject(ISceneObject sceneObject) => _sceneObject = sceneObject;
        public void Load() => _sceneObject.Load();
        public T GetMetadata<T>() where T : class, ISceneMetadata => _sceneObject.GetMetadata<T>();
    }
}
