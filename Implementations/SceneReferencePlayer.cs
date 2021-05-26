using UnityEngine;

namespace FedoraDev.SceneObject.Implementations
{
    public partial class SceneReference
    {
        [SerializeField] string _scenePath = string.Empty;

#if UNITY_EDITOR
#else
        public string GetScenePath(Object sceneAsset) => return _scenePath;
        public bool IsValidSceneAsset(Object sceneAsset) => true;
        
        public void SetScenePath(string value) { }
        public void OnBeforeSerialize(Object sceneAsset) { }
        public void OnAfterDeserialize(Object sceneAsset) { }
#endif
    }
}
