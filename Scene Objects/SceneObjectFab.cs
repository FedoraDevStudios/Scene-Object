using MochaMoth.SceneObject.SceneObjects;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace MochaMoth.SceneObject
{
	public class SceneObjectFab : SerializedScriptableObject
	{
		public ISceneObject SceneObject => _sceneObjectFab.Produce();

		[OdinSerialize] ISceneObject _sceneObjectFab;
	}
}
