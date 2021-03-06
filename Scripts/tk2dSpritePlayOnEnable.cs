using UnityEngine;
using System.Collections;

[AddComponentMenu("M8/tk2D/PlayOnEnable")]
public class tk2dSpritePlayOnEnable : MonoBehaviour {

    public tk2dSpriteAnimator sprite;
    public string clip;

    public float minDelay;
    public float maxDelay;

    public bool stopOnDisable = true;

    private bool mStarted = false;

    private tk2dSpriteAnimationClip mClipPlay;

    void OnEnable() {
        if(mStarted)
            DoIt();
    }

    void OnDisable() {
        if(sprite != null)
            sprite.Stop();

        CancelInvoke("PlayDelayed");
    }

    void Awake() {
        if(sprite == null)
            sprite = GetComponent<tk2dSpriteAnimator>();

        if(string.IsNullOrEmpty(clip))
            mClipPlay = null;
        else {
            mClipPlay = sprite.GetClipByName(clip);
        }

        sprite.playAutomatically = false;
    }

    void Start() {
        mStarted = true;
        DoIt();
    }

    void DoIt() {
        if(maxDelay > 0 || minDelay > 0) {
            if(minDelay < maxDelay)
                Invoke("PlayDelayed", Random.Range(minDelay, maxDelay));
            else
                Invoke("PlayDelayed", minDelay);
        }
        else {
            sprite.Play(mClipPlay != null ? mClipPlay : sprite.DefaultClip);
        }
    }

    void PlayDelayed() {
        sprite.Play(mClipPlay != null ? mClipPlay : sprite.DefaultClip);
    }
}
