using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace compassmod
{
    public class Compass : MonoBehaviour
    {
        public RawImage CompassImage;
        public TextMeshProUGUI NeedleText;

        // Update is called once per frame
        void Update()
        {
            var angle = EulerAnglesY();
            CompassImage.uvRect =new Rect(angle/360f, 0f, 1f, 1f);
            NeedleText.text = angle.ToString("F0") + "°";
        }

        private static float EulerAnglesY()
        {
            try
            {
                return (PlayerStateWindow.Instance.Parent.EntityRotation.eulerAngles.y + 180.0f) % 360.0f;
                //return PlayerStateWindow.Instance.Parent.EntityRotation.eulerAngles.y;
            }
            catch (Exception ex)
            {
                return 0f;
            }

        }
    }
}
