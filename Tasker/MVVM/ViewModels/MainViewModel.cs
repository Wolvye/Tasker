
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.MVVM.Models;

namespace Tasker.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
           UpdateData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Online",
                    Color= "#CF14DF"
                },
                  new Category
                {
                    Id = 2,
                    CategoryName = "Einkaufen",
                    Color= "#df6f14"
                },
                    new Category
                {
                    Id = 3,
                    CategoryName = "Weltherrschaft",
                    Color= "#14df80"
                },
            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Upload YT",
                    Completed = false,
                    CategoryId = 1
                },
                  new MyTask
                {
                    TaskName = "Upload TikTok",
                    Completed = false,
                    CategoryId = 1
                },
                 new MyTask
                {
                    TaskName = "Download CornHub",
                    Completed = false,
                    CategoryId = 1
                },
                 new MyTask
                {
                    TaskName = "Banana",
                    Completed = false,
                    CategoryId = 2
                },
                  new MyTask
                {
                    TaskName = "Fisch",
                    Completed = false,
                    CategoryId = 2
                },
                 new MyTask
                {
                    TaskName = "Wurst",
                    Completed = false,
                    CategoryId = 2
                },
                  new MyTask
                {
                    TaskName = "Trump wählen",
                    Completed = false,
                    CategoryId = 3
                },
        };

            UpdateData();

        }
        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;

                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
               // System.Diagnostics.Debug.WriteLine($"Category: {c.CategoryName} → Percentage: {c.Percentage}");

            }
            foreach (var t in Tasks)
            {
                var catColor =
                    (from c in Categories
                     where c.Id == t.CategoryId
                     select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
