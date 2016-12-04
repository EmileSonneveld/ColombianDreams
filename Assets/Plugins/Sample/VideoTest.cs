using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class VideoTest : MonoBehaviour
{
	private WebGLMovieTexture tex;
	public GameObject cube;
	public Texture2D testTexture;

	void Start()
	{
		moviePath = "StreamingAssets/JAGUAR_CLIP_2.mp4";
		//tex = new WebGLMovieTexture();
		//cube.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
		//cube.GetComponent<MeshRenderer>().material.mainTexture = tex;
	}
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
			{
				tex.loop = true;
				tex.Play();
			}
		}
	}

	void Update()
	{
			if (tex != null)
		tex.Update();
		//cube.transform.Rotate(Time.deltaTime * 10, Time.deltaTime * 30, 0);
	}

	void OnGUI()
	{
#if UNITY_WEBGL && !UNITY_EDITOR
#else
		return;
#endif

		GUI.enabled = tex.isReady;

		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Play"))
			tex.Play();
		/*if (GUILayout.Button("Pause"))
			tex.Pause();
		tex.loop = GUILayout.Toggle(tex.loop, "Loop");
		GUILayout.EndHorizontal();

		var oldT = tex.time;
		var newT = GUILayout.HorizontalSlider(tex.time, 0.0f, tex.duration);
		if (!Mathf.Approximately(oldT, newT))
			tex.Seek(newT);
			*/
		GUI.enabled = true;
	}
}
