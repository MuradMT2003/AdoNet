using AdoNet.Helpers;
using AdoNet.Models;
using AdoNet.Services.Interfaces;
using System.Data;

namespace AdoNet.Services.Implements
{
    public class FilialService:IFilialService
    {
        public async Task<int> AddAsync(Filial Filial)
        {
            return await SqlHelper.ExecuteAsync($"INSERT INTO Filial VALUES ('{Filial.Name}')");
        }

        public async Task<int> AddAsync(List<Filial> Filial)
        {
            string query = "INSERT INTO Filial VALUES";
            foreach (var item in Filial)
            {
                query += $"(N'{item.Name})";
            }
            return await SqlHelper.ExecuteAsync(query.Substring(0, query.Length - 1));
        }

        public async Task<int> Delete(int id)
        {
            await GetByIdAsync(id);
            return await SqlHelper.ExecuteAsync("DELETE * FROM Filial =" + id);
        }

        public async Task<List<Filial>> GetAllAsync()
        {
            List<Filial> list = new List<Filial>();
            DataTable dt = await SqlHelper.SelectAsync("SELECT * FROM Filial");
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new Filial
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Name"]
                });
            }
            return list;
        }

        public async Task<Filial> GetByIdAsync(int id)
        {
            DataTable dt = await SqlHelper.SelectAsync("SELECT * FROM Filial where Id = " + id);
            if (dt.Rows.Count != 1) throw new Exception("Error");
            return new Filial
            {
                Id = (int)dt.Rows[0]["Id"],
                Name = (string)dt.Rows[0]["Name"]
            };

        }

        public async Task<int> Update(int id, Filial filial)
        {
            await GetByIdAsync(id);
            return await SqlHelper.ExecuteAsync("Update filial Set Name=" + filial.Name);
        }
    }
}
