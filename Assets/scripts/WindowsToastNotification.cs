using UnityEngine;
using System.Diagnostics;

public class WindowsToastNotification : MonoBehaviour
{
    public void SendNotification()
    {
        string title = "Il est temps de regarder dehors";
        string message = "Il est temps de regarder dehors";

        string command = $"[Windows.UI.Notifications.ToastNotificationManager, Windows.UI.Notifications, ContentType=WindowsRuntime] | Out-Null; " +
                         $"$Template = [Windows.UI.Notifications.ToastTemplateType]::ToastText02; " +
                         $"$ToastXml = [Windows.UI.Notifications.ToastNotificationManager]::GetTemplateContent($Template); " +
                         $"$ToastXml.GetElementsByTagName('text')[0].AppendChild($ToastXml.CreateTextNode('{title}')) | Out-Null; " +
                         $"$ToastXml.GetElementsByTagName('text')[1].AppendChild($ToastXml.CreateTextNode('{message}')) | Out-Null; " +
                         $"$Toast = [Windows.UI.Notifications.ToastNotification]::new($ToastXml); " +
                         $"[Windows.UI.Notifications.ToastNotificationManager]::CreateToastNotifier('Unity').Show($Toast)";

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = $"-ExecutionPolicy Bypass -NoProfile -Command \"{command}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = new Process { StartInfo = psi };
        process.Start();
    }

    // Test avec une touche
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SendNotification();
        }
    }
}