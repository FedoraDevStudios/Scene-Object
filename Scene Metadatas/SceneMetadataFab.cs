using MochaMoth.SceneObject.SceneMetadatas;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace MochaMoth.SceneObject
{
	public class SceneMetadataFab : SerializedScriptableObject
	{
		public ISceneMetadata SceneMetadata => _sceneMetadataFab.Produce();

		[OdinSerialize] ISceneMetadata _sceneMetadataFab;
	}
}
