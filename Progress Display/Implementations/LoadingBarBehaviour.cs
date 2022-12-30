using Sirenix.OdinInspector;
using UnityEngine;

namespace MochaMoth.SceneObject.ProgressDisplays.Implementations
{
	public class LoadingBarBehaviour : SerializedMonoBehaviour
	{
		[SerializeField] IProgressDisplay _progressDisplay;

		public void Progress(float value)
		{
			if (_progressDisplay != null)
				_progressDisplay.Progress(value);
		}
	}
}
