using Sirenix.OdinInspector;
using UnityEngine;

namespace FedoraDev.SceneObject.Implementations
{
    public class LoadingBarBehaviour : SerializedMonoBehaviour
    {
		[SerializeField] IDisplayProgress _progressDisplay;

		public void SetSliderValue(float value)
		{
			if (_progressDisplay != null)
				_progressDisplay.Progress(value);
		}
	}
}
