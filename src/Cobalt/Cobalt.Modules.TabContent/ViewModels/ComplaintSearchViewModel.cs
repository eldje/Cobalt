using System;
using System.Collections.ObjectModel;
using Cobalt.Infrastructure;
using Cobalt.Infrastructure.Models;
using Cobalt.Modules.TabContent.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Cobalt.Modules.TabContent.ViewModels
{
    public class ComplaintSearchViewModel : BindableBase
    {
        private readonly IComplaintService _complaintService;
        private readonly IExpressionBuilder _expressionBuilder;
        private readonly IRegionManager _regionManager;

        public ComplaintSearchViewModel(IComplaintService complaintService, IRegionManager regionManager,
            IExpressionBuilder expressionBuilder)
        {
            _complaintService = complaintService;
            _regionManager = regionManager;
            _expressionBuilder = expressionBuilder;

            SearchFilters = new ObservableCollection<Filter>();

            SearchCommand = new DelegateCommand(Search);
            AddFilterCommand = new DelegateCommand(AddSearchFilter);
        }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand AddFilterCommand { get; set; }

        public ObservableCollection<Filter> SearchFilters { get; set; }

        public string ErrorMessage { get; set; }
        public string PropertySelectedItem { get; set; }

        private void AddSearchFilter()
        {
            if (SearchFilters.Count == 13) return;

            SearchFilters.Add(new Filter());
        }

        private void Search()
        {
            var complaints = _complaintService.GetComplaintsWhere(GetLinqExpression());

            if (complaints == null)
            {
                ErrorMessage = "No results found";
                return;
            }

            var paramter = new NavigationParameters {{"Results", complaints}};
            _regionManager.RequestNavigate(RegionNames.ComplaintRegion, new Uri("ComplaintGridView", UriKind.Relative),
                paramter);
        }

        private string GetLinqExpression()
        {
            return _expressionBuilder.BuildExpression(SearchFilters);
        }
    }
}