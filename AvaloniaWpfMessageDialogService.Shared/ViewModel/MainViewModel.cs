using AvaloniaWpfMessageDialogService.Shared.Service;
using Prism.Commands;
using System;
using System.Diagnostics;

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

        private async void TestMessageDialogServiceExecute()
        {
            var result = await _messageDialogService.ShowOkCancelDialog(this, $"This is a OkCancelDialog" +
                $"{Environment.NewLine}{Environment.NewLine}" +
                $"Click ok to see InfoDialog", "Question");

                if (result == MessageDialogResult.Ok)
                {
                    _messageDialogService.ShowInfoDialog("This is a InfoDialog", "Info");
                }
        }
    }
}
