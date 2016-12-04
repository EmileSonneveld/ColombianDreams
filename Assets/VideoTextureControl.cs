using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoTextureControl : MonoBehaviour
{

	private WebGLMovieTexture tex;
	public Texture2D testTexture;
	private string _moviePath;
	
	public string moviePath
	{
		get
		{
			return _moviePath;
		}
		set
		{
			if (_moviePath == value) return;

			_moviePath = value;

			this.gameObject.SetActive(!string.IsNullOrEmpty(value));
			//if (tex != null)
			//	tex.Pause();
#if UNITY_WEBGL && !UNITY_EDITOR
			tex = new WebGLMovieTexture(_moviePath);
			Texture2D tmpTex = tex;
#else
			Texture2D tmpTex = testTexture;
#endif
			var mesh = this.GetComponentInChildren<MeshRenderer>();
			if (mesh)
			{
				mesh.material = new Material(Shader.Find("Diffuse"));
				mesh.material.mainTexture = tmpTex;
			}
			else
			{
				Image img = GetComponentInChildren<Image>();
				Sprite sp = Sprite.Create(tmpTex, new Rect(0, 0, tmpTex.width, tmpTex.height), img.sprite.pivot);
				img.sprite = sp;
			}
			if (tex != null)
				tex.Play();
		}
	}

	void Start()
	{

	}

	void Update()
	{
		if (tex != null)
			tex.Update();
	}

}
