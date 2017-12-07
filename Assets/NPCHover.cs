using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public GameObject npcHover;
	public GameObject[] invHover;

	void OnMouseOver(){
		npcHover.SetActive (true);
	}
	void OnMouseExit(){
		npcHover.SetActive (false);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		int pos = (int)this.gameObject.transform.localPosition.y;
		invHover[(pos-170)/(-50)].SetActive (true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		int pos = (int)this.gameObject.transform.localPosition.y;
		invHover[(pos-170)/(-50)].SetActive (false);
	}
}
