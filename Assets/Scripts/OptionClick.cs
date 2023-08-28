//Attatch this script to a Button GameObject
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OptionClick : MonoBehaviour, IPointerClickHandler
{
    public Dropdown OptionsContainer;

    public void OnPointerClick(PointerEventData eventData) {
        OptionsContainer.RefreshShownValue();
    }
}