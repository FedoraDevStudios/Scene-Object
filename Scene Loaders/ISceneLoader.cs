using MochaMoth.SceneObject.SceneObjects;
using System.Collections;

namespace MochaMoth.SceneObject.SceneLoaders
{
	public interface ISceneLoader
	{
		IEnumerator LoadAsync(ISceneObject sceneObject);
	}
}
