using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiAppTasker.MVVM.Models;
using PropertyChanged;

namespace MauiAppTasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TaskerViewModel
    {
        public ObservableCollection<TaskerModel> CategoryList { get; set; }
        public ObservableCollection<MyTaskModel> Tasks { get; set; }


        public TaskerViewModel()
        {
            FillData();
            Tasks.CollectionChanged += TaskCollectionChanged;
        }

        private void TaskCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            CategoryList = new ObservableCollection<TaskerModel>
               {
                   new TaskerModel
                   {
                       Id = 1,
                       CategoryName = "Fitness",
                       Color = "#CF14DF"
                   },
                   new TaskerModel
                   {
                       Id = 2,
                       CategoryName = "Skill Development",
                       Color = "#df6f14"
                   },
                   new TaskerModel
                   {
                       Id = 3,
                       CategoryName = "Shopping",
                       Color = "#14df80"
                   }
               };
            Tasks = new ObservableCollection<MyTaskModel>
               {
                   new MyTaskModel
                   {
                       TaskName = "Gym",
                       CategoryId = 1,
                       Completed = false
                   },
                   new MyTaskModel
                   {
                       TaskName = "Yoga",
                       CategoryId = 1,
                       Completed = true
                   },
                   new MyTaskModel
                   {
                       TaskName = "Guitar",
                       CategoryId = 2,
                       Completed = false
                   },
                   new MyTaskModel
                   {
                       TaskName = "Shopping",
                       CategoryId = 3,
                       Completed = true
                   }
               };
            UpdateData();
        }
        public void UpdateData()
        {

            foreach (var c in CategoryList)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;
                var completed = from t in tasks
                                where t.Completed == true
                                select t;
                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;
                c.PendingTasks = notCompleted.Count();
                c.Percentage = ((float)completed.Count() / (float)tasks.Count());
            }
            foreach (var t in Tasks)
            {
                var catColor = (from c in CategoryList
                                where c.Id == t.CategoryId
                                select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }

    } 
}
 