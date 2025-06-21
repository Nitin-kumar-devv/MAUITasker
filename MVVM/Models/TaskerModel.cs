using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MauiAppTasker.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class TaskerModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public int PendingTasks { get; set; }
        public float Percentage { get; set; }
        public bool IsSelected { get; set; }
    }
}
