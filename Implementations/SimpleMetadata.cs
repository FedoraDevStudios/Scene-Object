using UnityEngine;

namespace FedoraDev.SceneObject.Implementations
{
	public class SimpleMetadata : ISceneMetadata
    {
        [SerializeField] string _sceneName;

		public string SceneName => _sceneName;
	}
}
