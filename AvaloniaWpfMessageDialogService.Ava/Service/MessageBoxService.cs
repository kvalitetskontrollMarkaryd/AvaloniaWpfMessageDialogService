using Avalonia.Controls;
using AvaloniaWpfMessageDialogService.Shared.Helper;
using AvaloniaWpfMessageDialogService.Shared.Service;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using System.Threading.Tasks;

namespace AvaloniaWpfMessageDialogService.Ava.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        private readonly ICustomViewLocator _customViewLocator;

        public MessageBoxService(ICustomViewLocator customViewLocator)
        {
            _customViewLocator = customViewLocator;
        }

        public async Task<MessageDialogResult> ShowOkCancelDialog<TParent>(TParent parent, string text, string title) where TParent : class
        {
            var parentWindow = _customViewLocator.GetViewFor(parent) as Window;

            var msBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ButtonDefinitions = ButtonEnum.OkCancel,
                    ContentTitle = title,
                    ContentMessage = text,
                    Icon = Icon.Warning,
                    Style = Style.UbuntuLinux,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });
            var buttonResult = await msBoxStandardWindow.ShowDialog(parentWindow);
           
            if (buttonResult == ButtonResult.Ok)
            {
                return MessageDialogResult.Ok;
            }
            if (buttonResult == ButtonResult.Cancel)
            {
                return MessageDialogResult.Cancel;
            }
            return MessageDialogResult.Cancel;
        }

        public void ShowInfoDialog(string text, string title)
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ButtonDefinitions = ButtonEnum.Ok,
                    ContentTitle = title,
                    ContentMessage = text,
                    Icon = Icon.Info,
                    Style = Style.UbuntuLinux,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                });
            messageBoxStandardWindow.Show();
        }
    }
}
