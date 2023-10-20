using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace rwe_tgwe
{

    public class ViewModel
    {
        private int index ;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public ICommand ShowCommand { get; }
        public ViewModel()
        {
            ShowCommand = new ShowCommand(this);
            
        }
    }
}
