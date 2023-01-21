using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenResoiution : MonoBehaviour
{
    [SerializeField] public TMP_Dropdown _permission;
  

    public void Permission()
    {
        switch(_permission.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true); 
            break;
            case 1:
                Screen.SetResolution(1366, 768, true);
            break;
            case 2:
                Screen.SetResolution(2560, 1440, true);
            break;
                case 3:
                Screen.SetResolution(3840, 2160, true);
             break;
               default:
            Screen.SetResolution(1920, 1080, true);
                break;
        }

    }
}
