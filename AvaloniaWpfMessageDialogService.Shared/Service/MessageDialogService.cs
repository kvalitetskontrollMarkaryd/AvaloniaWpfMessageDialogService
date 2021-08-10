using System.Threading.Tasks;

namespace AvaloniaWpfMessageDialogService.Shared.Service
{
    public class MessageDialogService : IMessageDialogService
    {
        private readonly IMessageBoxService _messageBoxService;

        public MessageDialogService(IMessageBoxService windowService)
        {
            _messageBoxService = windowService;
        }

        public Task<MessageDialogResult> ShowOkCancelDialog<TParent>(TParent parent, string text, string title = null) where TParent : class
        {
            return _messageBoxService.ShowOkCancelDialog(parent, text, title);
        }

        public void ShowInfoDialog(string text, string title)
        {
            _messageBoxService.ShowInfoDialog(text, title);
        }
    }
}
