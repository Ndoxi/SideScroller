using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ControlsScrollView : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform contentPanel;
    [SerializeField] private float padding = 2.5f;


    public void SnapTo(GameObject target)
    {
        Canvas.ForceUpdateCanvases();
        RectTransform targetRectTransform = target.GetComponent<RectTransform>();
       
        Vector2 scrollPosition = scrollRect.transform.InverseTransformPoint(targetRectTransform.position); //Button position
        float elementTop = scrollPosition.y + targetRectTransform.rect.height / 2;
        float elementBottom = elementTop - targetRectTransform.rect.height / 2;

        Vector2 visibleContentPos = scrollRect.transform.position; //Content position
        float viewportHeight = scrollRect.viewport.rect.height;
        float visibleContentTop = visibleContentPos.y + viewportHeight / 2 - padding; //max Y position
        float visibleContentBottom = visibleContentPos.y - viewportHeight / 2 + padding; //min Y position

        float scrollDelta =
            elementTop > visibleContentTop ? visibleContentTop - targetRectTransform.rect.height :
            elementBottom < visibleContentBottom ? visibleContentBottom + targetRectTransform.rect.height :
            0;

        float posX = scrollRect.transform.InverseTransformPoint(contentPanel.position).x;
        float posY = scrollRect.transform.InverseTransformPoint(contentPanel.position).y - scrollDelta / 2;

        contentPanel.anchoredPosition = new Vector2(posX, posY);
    }
}