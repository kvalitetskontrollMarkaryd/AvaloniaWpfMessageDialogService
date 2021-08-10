using AvaloniaWpfMessageDialogService.Shared.Service;
using System.Threading.Tasks;
using System.Windows;

namespace AvaloniaWpfMessageDialogService.Wpf.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowInfoDialog(string text, string title)
        {
            MessageBox.Show(text, title);
        }

        public async Task<MessageDialogResult> ShowOkCancelDialog<TParent>(TParent parent, string text, string title) where TParent : class
        {
            var result = await Task.FromResult(MessageBox.Show(text, title, MessageBoxButton.OKCancel));

            if (result == MessageBoxResult.OK)
            {
                return MessageDialogResult.Ok;
            }
            if (result == MessageBoxResult.Cancel)
            {
                return MessageDialogResult.Cancel;
            }
            return MessageDialogResult.Cancel;
        }
    }
}
