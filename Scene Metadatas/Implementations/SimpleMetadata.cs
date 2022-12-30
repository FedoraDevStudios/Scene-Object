using UnityEngine;

namespace MochaMoth.SceneObject.SceneMetadatas.Implementations
{
	public class SimpleMetadata : ISceneMetadata
	{
		[SerializeField] string _sceneName;

		public string SceneName => _sceneName;

		public ISceneMetadata Produce() => new SimpleMetadata();
	}
}
