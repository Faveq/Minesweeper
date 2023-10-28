using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Commands
{
    public class ClickCommand : BaseCommand
    {
        private ViewModel _viewModel;

        public ClickCommand(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }


        public override void Execute(object? parameter)
        {
            Debug.WriteLine(_viewModel.SelectedIndex);
        }
    }
}
