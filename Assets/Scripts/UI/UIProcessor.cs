using UnityEditor;
using UnityEngine;

namespace UI
{
    public class UIProcessor : MonoBehaviour
    {
        public UIMenu BuildingMenu; 

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                BuildingMenu.SwitchActivityState();

            }

        }
    }
}
