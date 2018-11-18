using AppSQlite.Interfaces;
using AppSQlite.UWP.Services;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using Windows.UI.Notifications;

[assembly: Xamarin.Forms.Dependency(typeof(MessageUWP))]

namespace AppSQlite.UWP.Services
{
    public class MessageUWP : IMessage
    {
        private void ShowAlert(string message, int duration)
        {
            ToastContent content = new ToastContent()
            {
                Duration = duration == 0 ? ToastDuration.Short : ToastDuration.Long,
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                                {
                                    Text = message
                                }
                        }
                    }
                }
            };

            var toast = new ToastNotification(content.GetXml());
            toast.ExpirationTime = DateTime.Now.AddSeconds(20);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public void LongAlert(string message)
        {
            this.ShowAlert(message, 1);
        }

        public void ShortAlert(string message)
        {
            this.ShowAlert(message, 0);
        }
    }
}