using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : Interactable {

    public VideoClip videoClip;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;

    private long _currentFrame;

	// Use this for initialization
	void Start () {
        _videoPlayer = gameObject.AddComponent<VideoPlayer>();
        _audioSource = gameObject.AddComponent<AudioSource>();

        _videoPlayer.playOnAwake = false;
        _videoPlayer.clip = videoClip;
        _videoPlayer.isLooping = true;
        _videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        _videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        _videoPlayer.targetMaterialProperty = "_MainTex";
        _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        _videoPlayer.SetTargetAudioSource(0, _audioSource);

        _currentFrame = 0;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public override void Interact()
    {
        base.Interact();

        if (_videoPlayer.isPlaying)
        {
            _currentFrame = _videoPlayer.frame;
            _videoPlayer.Stop();
        }
        else
        {
            _videoPlayer.frame = _currentFrame;
            _videoPlayer.Play();
        }
    }
}
