using Bully.Models;
using System.Collections.ObjectModel;

namespace Bully.Services.Menu
{
    public interface IMenuService
	{
		ObservableCollection<MenuItem> LoadMenu();


	}
}

