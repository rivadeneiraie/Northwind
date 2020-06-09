using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Northwind.Repositories;
using Dapper.Contrib.Extensions;

namespace Northwind.DataAcces
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected string _connectionString; 
        public Repository(string connectionString){

            SqlMapperExtensions.TableNameMapper = (Type) => { return $"{ Type.Name }"; };
            _connectionString = connectionString;
        }
        public T GetById(int id){

            using (var connection = new SqlConnection(_connectionString)){
            
                return connection.Get<T>(id);
            }
        }
        public IEnumerable<T> GetList() {
            
            using (var connection = new SqlConnection(_connectionString)){
            
                return connection.GetAll<T>();
            }
        }
        public int Insert(T entity){
            
            using (var connection = new SqlConnection(_connectionString)){
            
                return (int)connection.Insert(entity);
            }
        }
        public bool Delete(T entity){

            using (var connection = new SqlConnection(_connectionString)){
            
                return connection.Delete(entity);
            }
        }
        public bool Update(T entity){
            
            using (var connection = new SqlConnection(_connectionString)){
            
                return connection.Update(entity);
            }
        }

    }
}
