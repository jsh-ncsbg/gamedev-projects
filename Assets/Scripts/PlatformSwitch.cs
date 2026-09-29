using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    enum SwitchAction { Toggle, Pause, Resume }

    [SerializeField]
    SwitchAction action = SwitchAction.Toggle;

    [SerializeField]
    List<MovingPlatform> movingPlatforms = new();

    [SerializeField]
    List<Spinner> spinners = new();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }

        foreach (MovingPlatform platform in movingPlatforms)
        {
            if (action == SwitchAction.Toggle) platform.Toggle();
            else if (action == SwitchAction.Pause) platform.Pause();
            else platform.Resume();
        }

        foreach (Spinner spinner in spinners)
        {
            if (action == SwitchAction.Toggle) spinner.Toggle();
            else if (action == SwitchAction.Pause) spinner.Pause();
            else spinner.Resume();
        }
    }
}
