using System.Collections;
using UnityEngine;

public interface ISceneLoader
{
    IEnumerator LoadAsync(ISceneObject sceneObject);
}
