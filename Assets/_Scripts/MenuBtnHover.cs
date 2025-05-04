using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts
{
    public class MenuBtnHover : MonoBehaviour,IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            SoundManager.Instance.PlaySound3D("HoverMenu",transform.position);
        }
    }
}