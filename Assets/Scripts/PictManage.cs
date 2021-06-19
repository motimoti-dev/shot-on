using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyPictManage
{
    public class PictManage : MonoBehaviour
    {
        private Sprite sp;

        GameObject gm;
        //初めから生成し、シーン遷移しても値が受け継がれるように消えないオブジェクトにする
        private void Start()
        {
            gm = this.gameObject;
            DontDestroyOnLoad(gm);
        }
        /**
         * 写真選択のGetter,Setter
         * RawCameraに渡す
         */

        public Sprite SpManage
        {
            get { return sp; }

            set { sp = value; }
        }

    }
}
