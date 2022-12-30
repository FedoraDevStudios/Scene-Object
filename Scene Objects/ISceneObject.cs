using MochaMoth.SceneObject.SceneMetadatas;

namespace MochaMoth.SceneObject.SceneObjects
{
	public interface ISceneObject
	{
		string ScenePath { get; }
		T GetMetadata<T>() where T : class, ISceneMetadata;
		ISceneObject Produce();
	}
}