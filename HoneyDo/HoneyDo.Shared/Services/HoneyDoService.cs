using HoneyDo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HoneyDo.Shared.Services
{
    internal class HoneyDoService
    {
        private static List<HoneyDoModel>? myModel = null;
        private const string ModelName = "HoneyDoModel";

        public static List<HoneyDoModel> GetModel(ILocalStorage storage)
        {
            if (myModel == null)
            {
                string jsonString = storage.GetItem(ModelName);
                if (jsonString != null)
                {
                    myModel = JsonSerializer.Deserialize<List<HoneyDoModel>>(jsonString);
                }
            }
            if (myModel == null)
            {
                myModel = new List<HoneyDoModel>();
                myModel.Add(new HoneyDoModel { Id = 1, Task = "Task 1", Description = "Description 1", IsComplete = false, DueDate = DateTime.Now.AddDays(1), AssignedTo = "Nick", CreatedBy = "Beth", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
                myModel.Add(new HoneyDoModel { Id = 2, Task = "Task 2", Description = "Description 2", IsComplete = false, DueDate = DateTime.Now.AddDays(2), AssignedTo = "Nick", CreatedBy = "Beth", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
                myModel.Add(new HoneyDoModel { Id = 3, Task = "Task 3", Description = "Description 3", IsComplete = false, DueDate = DateTime.Now.AddDays(2), AssignedTo = "Nick", CreatedBy = "Beth", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });

            }
            return myModel;
        }

        public static HoneyDoModel GetModelById(int id, ILocalStorage storage)
        {
            if (myModel == null)
            {
                myModel = GetModel(storage);
            }
            var item = myModel?.FirstOrDefault(m => m.Id == id);
            return item;
        }

        public static void SaveModel(ILocalStorage storage)
        {
            if (myModel == null)
            {
                return;
            }
            string jsonString = JsonSerializer.Serialize(myModel);
            storage.SetItem(ModelName, jsonString);
        }

        public static HoneyDoModel AddItem()
        {
            var model = new HoneyDoModel();
            if (myModel != null)
            {
                myModel.Add(model);
                if (model.Id == 0)
                {
                    model.Id = myModel.Max(m => m.Id) + 1;
                }
            }
            return model;
        }
        public static void AddItem(HoneyDoModel model)
        {
            if (myModel != null)
            {
                myModel.Add(model);
                if (model.Id == 0)
                {
                    model.Id = myModel.Max(m => m.Id) + 1;
                }
            }
        }
        public static void RemoveItem(HoneyDoModel model)
        {
            myModel?.Remove(model);
        }

        public static List<HoneyDoModel> ReloadModel(ILocalStorage storage)
        {
            myModel = null;
            return GetModel(storage);
        }
    }
}
