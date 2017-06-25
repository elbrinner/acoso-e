using Bully.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bully.Interfaces.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task NavigateToAsync(Type viewModelType);

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();

    }
}
