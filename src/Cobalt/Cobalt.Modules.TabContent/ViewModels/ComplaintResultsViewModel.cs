using System.Collections.Generic;
using Cobalt.DataAccess.Models;
using Cobalt.Infrastructure.Collections;
using Cobalt.Modules.TabContent.Services.Interfaces;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;

namespace Cobalt.Modules.TabContent.ViewModels
{
    public class ComplaintResultsViewModel : BindableBase, INavigationAware
    {
        private readonly IComplaintService _complaintService;
        private DirtyCollection<Complaint> _complaints;
        private Complaint _selectedComplaint;

        public ComplaintResultsViewModel(IComplaintService complaintService)
        {
            _complaintService = complaintService;

            EditComplaintCommand = new DelegateCommand(EditComplaint);
            RemoveComplaintCommand = new DelegateCommand(RemoveComplaint);
            SaveCommand = new DelegateCommand(SaveComplaints);

            ConfrimDeleteRequest = new InteractionRequest<IConfirmation>();
        }

        public DirtyCollection<Complaint> Complaints
        {
            get { return _complaints; }
            set { SetProperty(ref _complaints, value); }
        }

        public Complaint SelectedComplaint
        {
            get { return _selectedComplaint; }
            set { SetProperty(ref _selectedComplaint, value); }
        }

        public DelegateCommand EditComplaintCommand { get; set; }
        public DelegateCommand RemoveComplaintCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public bool DiscardComplaintsIsEnabled
        {
            get { return Complaints.IsDirty; }
        }

        public InteractionRequest<IConfirmation> ConfrimDeleteRequest { get; set; }

        public void EditComplaint()
        {
            ConfrimDeleteRequest.Raise(
                new Confirmation {Title = "Hello", Content = "Are you sure you want to delete this complaint?"},
                confirmation =>
                {
                });
        }

        private void AddComplaint()
        {
            var complaint = new Complaint();
            Complaints.Add(complaint);
        }

        private void RemoveComplaint()
        {
            ConfrimDeleteRequest.Raise(new Confirmation {Title = "Confrim", Content = "Are you sure you want to delete this complaint?"}, confirmation =>
            {
                if (!confirmation.Confirmed) return;
                Complaints.Remove(SelectedComplaint);
            });
        }

        private void RefreshComplaints()
        {
            Complaints.Clear();
            //Complaints = new DirtyCollection<Complaint>(_complaintService.GetComplaintsWhere(c => c));
        }

        private void DiscardChanges()
        {
            if (Complaints.IsDirty)
            {
                ConfrimDeleteRequest.Raise(
                    new Confirmation {Title = "Confrim", Content = "Are you sure you want to discard all changes?"},
                    confirmation =>
                    {
                        //Complaints = new DirtyCollection<Complaint>(_complaintService.GetComplaintsWhere(c => c));
                    });
            }
            else
            {

            }
        }

        public void SaveComplaints()
        {
            _complaintService.Save();
        }

        public void ClearComplaints()
        {
            if (Complaints.IsDirty)
            {
                ConfrimDeleteRequest.Raise(new Confirmation{Title = "", Content = ""}, confirmation =>
                {
                    if (!confirmation.Confirmed) return;
                    Complaints.Clear();
                    Complaints.Clean();
                });
            }
            else
            {
                Complaints.Clear();
                Complaints.Clean();
            }
        }

        public void SaveAll()
        {
            _complaintService.Save();
        }

        public bool CanSave()
        {
            return Complaints.IsDirty;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var complaints = navigationContext.Parameters["Results"] as List<Complaint>;

            Complaints = new DirtyCollection<Complaint>(complaints);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
