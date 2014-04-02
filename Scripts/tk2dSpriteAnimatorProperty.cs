using UnityEngine;
using System.Collections;

[AddComponentMenu("M8/tk2D/SpriteAnimatorProperty")]
public class tk2dSpriteAnimatorProperty : MonoBehaviour {
    private tk2dSpriteAnimator mAnim;
    //private int mSpriteId;

    public string clip {
        get {
            return mAnim.CurrentClip.name;
        }

        set {
            mAnim.Play(value);
        }
    }

    void Awake() {
        mAnim = GetComponent<tk2dSpriteAnimator>();
        //mSpriteId = mSprite.spriteId;
    }
}
