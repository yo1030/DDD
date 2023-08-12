using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WPF.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
