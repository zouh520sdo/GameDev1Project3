using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : Interactable {

    public VideoClip goodClip;
    public VideoClip badClip;
    public VideoClip sadClip;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;
    private GameManager1 _gm;

    private long _currentFrame;

	// Use this for initialization
	void Start () {

        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager1>();
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
        _videoPlayer.clip = goodClip;
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

    public void PlayTV(VideoClip tvShow)
    {
        _videoPlayer.clip = tvShow;
        _videoPlayer.Play();
    }

    public void StopTV()
    {
        if (_videoPlayer.isPlaying)
        {
            _videoPlayer.Stop();
        }
    }

    public override void Interact()
    {
        base.Interact();

        if (_videoPlayer.isPlaying)
        {
            _currentFrame = _videoPlayer.frame;
            _videoPlayer.Stop();
            if (_videoPlayer.clip == badClip) {
              GlobalManager.instance.jobs.Add("Turned off the TV when an inappropriate video was playing (+1pts)");
              _gm.goodJobCounter++;
            }
            else if (_videoPlayer.clip == sadClip) {
              GlobalManager.instance.jobs.Add("Turned off the TV when an upsetting video was playing (+1pts)");
              _gm.goodJobCounter++;
            }
            else if (_videoPlayer.clip == goodClip)
            {
              GlobalManager.instance.jobs.Add("Turned off the TV when a pleasant video was playing (-1pts)");
              _gm.goodJobCounter--;
            }
        }
    }

    public override string getAction()
    {
        if (_videoPlayer.isPlaying)
        {
            return "Turn off TV";
        }

        return "";
    }
}
