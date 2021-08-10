namespace AvaloniaWpfMessageDialogService.Shared.Helper
{
    public interface ICustomViewLocator
    {
        object GetViewFor<TViewModel>(TViewModel viewModel);
    }
}
