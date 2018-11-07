using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : Interactable {

    public VideoClip videoClip;
    public VideoClip normal_tv_good;
    public VideoClip my_little_pony_good;
    public VideoClip back_dat_bad;
    public VideoClip weed_bad;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;

    private long _currentFrame;

	// Use this for initialization
	void Start () {


        _videoPlayer = GetComponent<VideoPlayer>();
        if (_videoPlayer == null)
        {
            _videoPlayer = gameObject.AddComponent<VideoPlayer>();
        }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        _videoPlayer.playOnAwake = false;
        _videoPlayer.clip = videoClip;
        _videoPlayer.isLooping = true;
        _videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        _videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        _videoPlayer.targetMaterialProperty = "_MainTex";
        _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        _audioSource.spatialize = true;
        _audioSource.spatialBlend = 1;
        _audioSource.maxDistance = 50;
        _audioSource.minDistance = 2;
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
