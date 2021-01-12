using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UnityChan
{

    [RequireComponent(typeof(Animator))]

    public class CharacterController : MonoBehaviour
    {

        private Animator anim;                      // Animatorへの参照
        private AnimatorStateInfo currentState;     // 現在のステート状態を保存する参照
        private AnimatorStateInfo previousState;    // ひとつ前のステート状態を保存する参照
        public bool _random = false;                // ランダム判定スタートスイッチ
        public float _threshold = 0.5f;             // ランダム判定の閾値
        public float _interval = 10f;				// ランダム判定のインターバル

        // Start is called before the first frame update
        void Start()
        {
            // 各参照の初期化
            anim = GetComponent<Animator>();
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            previousState = currentState;
            // ランダム判定用関数をスタートする
            //StartCoroutine("RandomChange");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("up"))
            {
                anim.SetBool("jump", true);
            }
            /*
            if (Input.GetKeyUp("up"))
            {
                anim.SetBool("jump", false);
            }
            */
            if (anim.GetBool("jump"))
            {
                // 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
                currentState = anim.GetCurrentAnimatorStateInfo(0);
                if (previousState.nameHash != currentState.nameHash)
                {
                    anim.SetBool("jump", false);
                    previousState = currentState;
                }
            }




            /*
            if (anim.GetBool("jump"))
            {
                
                anim.SetBool("jump", false);
                    
                
            }
            */
        }
    }
}
