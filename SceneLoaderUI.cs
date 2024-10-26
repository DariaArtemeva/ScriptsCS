using UnityEngine;
using UnityEngine.SceneManagement; 

namespace Valve.VR.InteractionSystem.Sample
{
    public class SceneLoaderUI : UIElement
    {
        

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnButtonClick()
        {
            base.OnButtonClick();

            SceneManager.LoadScene("1_Level");
        }
    }
}