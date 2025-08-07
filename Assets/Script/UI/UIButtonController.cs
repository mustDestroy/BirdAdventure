using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    class UIButtonController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
    {
        //public UnityEvent onClick;


        // LISENER FUNCTIONS
        public void OnPointerClick(PointerEventData eventData)
        {
            AudioController.uiAudioInstance.PlayClickSFX();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            AudioController.uiAudioInstance.PlayHoverSFX();
        }





    }
}
