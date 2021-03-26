using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AssetManage.ApplicationCore.Entity;
using MISA.AssetManage.ApplicationCore.Interfaces;
using MISA.AssetManage.ApplicationCore.models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace MISA.AssetManage.Infastructer
{
    public class baseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : BaseEntity
    {
        #region declare 
        /// <summary>
        /// Kết nối đến cơ sở dữ liệu
        /// </summary>
        string _stringConnection;
        protected IDbConnection _dbConnection;
        string className = typeof(MISAEntity).Name;

        #endregion

        #region constructer



        public baseRepository(IConfiguration stringConnection)
        {
            _stringConnection = stringConnection.GetConnectionString("MISACukCukConectionString");
            _dbConnection = new MySqlConnection(_stringConnection);
        }
        #endregion

        public IEnumerable<MISAEntity> GetAll()
        {

            string proc = $"Proc_Get{className}s";
            var obj = _dbConnection.Query<MISAEntity>(proc, commandType: CommandType.StoredProcedure);
            return obj;
        }

        public IEnumerable<MISAEntity> GetAllById(Guid entityID)
        {

            string proc = $"Proc_Get{className}ById";
            var dynamicParam = new DynamicParameters();
            dynamicParam.Add($"@{className}Id", entityID.ToString());
            var obj = _dbConnection.Query<MISAEntity>(proc, dynamicParam, commandType: CommandType.StoredProcedure);
            return obj;
        }


        public IEnumerable<MISAEntity> Fillter(string? contentFilter)
        {

            string proc = $"Proc_Filter{className}";
            var dynamicParam = new DynamicParameters();
            //dynamicParam.Add($"@{className}Id", entityID.ToString());
            dynamicParam.Add($"@{className}Code", contentFilter, DbType.String);
            dynamicParam.Add($"@{className}Name", contentFilter, DbType.String);
            dynamicParam.Add($"@depamentName", contentFilter, DbType.String);
            dynamicParam.Add($"@AssetType", contentFilter, DbType.String);
            var obj = _dbConnection.Query<MISAEntity>(proc, dynamicParam, commandType: CommandType.StoredProcedure);
            return obj;
        }

        public int Insert(MISAEntity entity)
        {

            string proc = $"Proc_Insert{className}";
            var res = _dbConnection.Execute(proc, entity, commandType: CommandType.StoredProcedure);
            return res;
        }

        public int UpdateByID(MISAEntity entity)
        {
            string proc = $"Proc_Update{className}ByID";
            var res = _dbConnection.Execute(proc, entity, commandType: CommandType.StoredProcedure);
            return res;
        }

        
        public int DeleteObject(string[] ids)
        {
            var listId = ids.Select(id => $"'{id}'").ToList();
            var idsQuery = string.Join(",", listId);
         
            var sql = $"DELETE FROM {className} WHERE {className}Id IN ({idsQuery})";
            var response = _dbConnection.Execute(sql, commandType: CommandType.Text);

            return response;
        }

        public MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo propertyInfo)
        {
            string propertyName = propertyInfo.Name;
            var propertyValue = propertyInfo.GetValue(entity);
            string query = null;
            var keyValueID = entity.GetType().GetProperty($"{className}Id").GetValue(entity);
            if (entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT * FROM {className} where {propertyName} = '{propertyValue}'";
            }
            else if (entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {className} where {propertyName} = '{propertyValue}' AND {className}Id <> '{keyValueID.ToString()}' ";
            }
            else
            {
                return null;
            }

            var res = _dbConnection.Query<MISAEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return res;
        }
    }
}
