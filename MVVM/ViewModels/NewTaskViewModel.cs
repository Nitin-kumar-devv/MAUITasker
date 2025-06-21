using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppTasker.MVVM.Models;

namespace MauiAppTasker.MVVM.ViewModels
{
    public class NewTaskViewModel
    {
        public string Task { get; set; }
        public ObservableCollection<MyTaskModel> Tasks { get; set; }
        public ObservableCollection<TaskerModel> Categories { get; set; }
    }
}
