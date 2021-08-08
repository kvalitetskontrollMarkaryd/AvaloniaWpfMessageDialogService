using AvaloniaWpfMessageDialogService.Shared.Service;
using Prism.Commands;
using System;

namespace AvaloniaWpfMessageDialogService.Shared.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMessageDialogService _messageDialogService;
        private string _text;

        public MainViewModel(IMessageDialogService messageDialogService)
        {
            _messageDialogService = messageDialogService;

            TestMessageDialogServiceCommand = new DelegateCommand(TestMessageDialogServiceExecute);

            Text = "This is a Text set in MainViewModel";
        }

        public string Text
        {
            get { return _text; }
            set 
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged();
            }
        }

        public DelegateCommand TestMessageDialogServiceCommand { get; }

        private void TestMessageDialogServiceExecute()
        {
            throw new NotImplementedException();
        }
    }
}
