using System.Collections;
using UnityEngine;

public interface ISceneLoader
{
    void Load(ISceneObject sceneObject);
    IEnumerator LoadAsync(ISceneObject sceneObject, GameObject routineObject, bool saveRoutineObject);
}
