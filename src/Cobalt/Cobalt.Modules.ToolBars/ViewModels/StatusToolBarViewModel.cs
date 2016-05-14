using System;
using Cobalt.Infrastructure.Enums;
using Cobalt.Infrastructure.Events;
using Cobalt.Infrastructure.Models;
using Prism.Events;
using Prism.Mvvm;

namespace Cobalt.Modules.ToolBars.ViewModels
{
    public class StatusToolBarViewModel : BindableBase
    {
        private string _applicationStatusImage;
        private string _applicationStatusMessage;

        public StatusToolBarViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ApplicationStatusEvent>().Subscribe(SetApplicationMessage);
        }

        public string ApplicationStatusImageDirectory
        {
            get { return _applicationStatusImage; }
            private set { SetProperty(ref _applicationStatusImage, value); }
        }

        public string ApplicationStatusMessage
        {
            get { return _applicationStatusMessage; }
            private set { SetProperty(ref _applicationStatusMessage, value); }
        }

        private void SetApplicationMessage(ApplicationStatusPayload payload)
        {
            switch (payload.ApplicationStatusEnum)
            {
                case ApplicationStatusEnum.Ready:
                    ApplicationStatusImageDirectory = "..\\Images\\tick-circle-frame.png";
                    break;
                case ApplicationStatusEnum.Warning:
                    ApplicationStatusImageDirectory = "..\\Images\\exclamation-circle.png";
                    break;
                case ApplicationStatusEnum.Error:
                    ApplicationStatusImageDirectory = "..\\Images\\cross-circle.png";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            ApplicationStatusMessage = payload.Message;
        }
    }
}