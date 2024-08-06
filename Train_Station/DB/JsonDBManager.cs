using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Train_Station.Station;
using Train_Station.Users;

namespace Train_Station.DB
{
    public class JsonDBManager<T> : IDBManager<T> where T : IDatabaseEntity
    {
        private string _jsonPath;
        private List<T> dBList;
        public List<T> DBList
        {
            get
            {
                if (dBList == null)
                {
                    dBList = GetAll();
                }
                return dBList;
            }
            set { dBList = value; }
        }

        public JsonDBManager(string jsonpath)
        {
            _jsonPath = jsonpath;
        }

        private List<T> GetAll()
        {
            string json = File.ReadAllText(_jsonPath);
            List<T> entities = JsonConvert.DeserializeObject<List<T>>(json);
            return entities;
        }

        private void SerializeJson()
        {
            string jsonString = JsonConvert.SerializeObject(DBList, Formatting.Indented);
            File.WriteAllText(_jsonPath, jsonString);
        }

        public T? GetById(int id)
        {
            List<T> entities = GetAll();
            T? entity = entities.FirstOrDefault(entity => entity.Id == id);
            return entity;
        }

        public void Update(T entity)
        {
            List<T> entities = GetAll();
            int currentEntity = entities.FindIndex(x => x.Id == entity.Id);

            entities[currentEntity] = entity;

            DBList = entities;
            SerializeJson();
        }
        public void Create(T entity)
        {
            DBList.Add(entity);
            SerializeJson();
        }

        public bool CheckIfIdExists(int id)
        {
            bool IdExists = DBList.Any(x => x.Id == id);
            return IdExists;
        }
    }
}
