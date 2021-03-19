using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OpenAudioFile : MonoBehaviour {

    [SerializeField]
    private InputField _iField;

    [SerializeField]
    private Button _playAudioButton;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public string soundPath;
    public string audioName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void
        Update () {
        audioName = _iField.text;
	}

    public void OpenFile()
    {
        soundPath = "file://" + Application.streamingAssetsPath + "/Audio/";
        StartCoroutine(LoadAudioFile());
    }

    private IEnumerator LoadAudioFile()
    {
        WWW request = GetAudioFromFile(soundPath, audioName);
        yield return request;

        audioClip = request.GetAudioClip();
        audioClip.name = audioName;
        PlayAudioFile();
    }

    private void PlayAudioFile()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = true;
    }

    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = string.Format(path + "{0}", fileName);
        WWW request = new WWW(audioToLoad);
        return request;
    }
}
