using UnityEditor;
using UnityEngine;

namespace UI
{
    public class UIProcessor : MonoBehaviour
    {
        public UIMenu BuildingMenu;
        public MouseLook MouseLook;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                BuildingMenu.SwitchActivityState();

            }

        }
    }
}
