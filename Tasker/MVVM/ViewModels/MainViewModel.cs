
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Test BLA BLA BLA",
                    Color= "#CF14DF"
                },
                  new Category
                {
                    Id = 2,
                    CategoryName = "Test2 PLUPLUPLUP",
                    Color= "#df6f14"
                },
                    new Category
                {
                    Id = 3,
                    CategoryName = "Test3DINGDONGDINGDONG",
                    Color= "#14df80"
                },
            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Upload BLA",
                    Completed = false,
                    CategoryId = 1
                },
                  new MyTask
                {
                    TaskName = "Upload BLALALALA",
                    Completed = true,
                    CategoryId = 2
                },
                 new MyTask
                {
                    TaskName = "Upload BLALALALA",
                    Completed = false,
                    CategoryId = 3
                },
                 new MyTask
                {
                    TaskName = "Upload BLA",
                    Completed = false,
                    CategoryId = 1
                },
                  new MyTask
                {
                    TaskName = "Upload BLALALALA",
                    Completed = true,
                    CategoryId = 2
                },
                 new MyTask
                {
                    TaskName = "Upload BLALALALA",
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

                var notCompleted = from t in Tasks
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
