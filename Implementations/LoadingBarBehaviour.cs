using UnityEngine;
using UnityEngine.UI;

namespace FedoraDev.SceneObject.Implementations
{
    [RequireComponent(typeof(Slider))]
    public class LoadingBarBehaviour : MonoBehaviour
    {
		private Slider _slider;

		private void Awake()
		{
			_slider = GetComponent<Slider>();
		}

		public void SetSliderValue(float value) => _slider.value = value;
	}
}
