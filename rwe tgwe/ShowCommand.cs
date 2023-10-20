using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rwe_tgwe
{
    public class ShowCommand : BaseCommand
    {
        private ViewModel viewModel;
        public ShowCommand(ViewModel Vm) {
            viewModel = Vm;
        }    


        public override void Execute(object? parameter)
        {
            Debug.WriteLine(viewModel.Index);
        }
    }
}
