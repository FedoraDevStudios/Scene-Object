using MochaMoth.SceneObject.SceneReferences;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace MochaMoth.SceneObject
{
	public class SceneReferenceFab : SerializedScriptableObject
	{
		public ISceneReference SceneReference => _sceneReferenceFab?.Produce();

		[OdinSerialize] ISceneReference _sceneReferenceFab;
	}
}
