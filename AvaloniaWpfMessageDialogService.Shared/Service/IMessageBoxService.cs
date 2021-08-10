using System.Threading.Tasks;

namespace AvaloniaWpfMessageDialogService.Shared.Service
{
    public interface IMessageBoxService
    {
        Task<MessageDialogResult> ShowOkCancelDialog<TParent>(TParent parent, string text, string title) where TParent : class;

        void ShowInfoDialog(string text, string title);
    }
}
