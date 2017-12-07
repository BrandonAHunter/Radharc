using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderManager : MonoBehaviour {

	public Slider text;
	public Slider music;
	public Slider SFX;
	private Vector3 screenPoint;
	private Vector3 offset;
	public bool IsDragable = true;

	// Use this for initialization
	void Start () {
		text.value = 1 - GameManager.Instance.TextSpeed * 10;
		music.value = GameManager.Instance.musicVolume;
		SFX.value = GameManager.Instance.SFXVolume;
	}

	public void updateText(float value){
		GameManager.Instance.TextSpeed = (1 - value) / 10;
	}

	public void updateMusic(float value){
		GameManager.Instance.musicVolume = value;
	}

	public void updateSFX(float value){
		GameManager.Instance.SFXVolume = value;
	}
}
