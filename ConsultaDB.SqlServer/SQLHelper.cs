using ConsultaDB.Entities;
using ConsultaDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaDB.SQLServer
{
    /// <summary>
    /// Clase SQL que aporta las diferentes funciones necesarias para
    /// trabajar con una base de datos SQL Server.
    /// </summary>
    public class SQLHelper : IDataHelper
    {
        const string conexionString = "Data Source=WIN-FIM5D2FXUQ\\SQLEXPRESS; Initial Catalog=EmpleadosAvanade;Integrated Security=true;";

        private SqlConnection cn;

        public SQLHelper()
        {
            cn = new SqlConnection(conexionString);
        }

        /// <summary>
        /// Función que devuelve una lista de personas que coincidan 
        /// con los parámetros de busqueda indicados.(Nombre y/o Apellido)
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Lista Personas</returns>
        public List<Person> GetListaPersonas(Person persona)
        {

            List<Person> resultadoConsulta = new List<Person>();
            SqlCommand cmd = new SqlCommand("getEmpleados", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = persona.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = persona.LastName;

            try {

                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.Id = Int32.Parse(reader["Id"].ToString());
                    person.FirstName = reader["FirstName"].ToString();
                    person.LastName = reader["LastName"].ToString();

                    resultadoConsulta.Add(person);
                };

            }
            catch(SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            
            return resultadoConsulta;
        }

        /// <summary>
        /// Función que devuelve una persona con una mayor cantidad de información.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Persona detallada</returns>
        public Person GetPersonaDetallada(int id)
        {
            Person persona = new Person();
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("getDetallesEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    persona.Id = Int32.Parse(reader["Id"].ToString());
                    persona.FirstName = reader["FirstName"].ToString();
                    persona.LastName = reader["LastName"].ToString();
                    persona.MiddleName= reader["MiddleName"].ToString();
                    persona.Title = reader["Title"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return persona;

        }

        public void AddPerson(Person person)
        {
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("addEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = person.MiddleName;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = person.Title;

                cmd.ExecuteNonQuery();

            }catch(SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void UpdatePerson(Person person)
        {
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("updateEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = person.Id;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
                cmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = person.MiddleName;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = person.Title;

                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


        public void DelPerson(int id)
        {
            SqlCommand cmd = null;

            try
            {
                cn.Open();

                cmd = new SqlCommand("deleteEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                throw new MiException(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Dispose()
        {
            if (cn != null)
                cn.Dispose();
        }

        /*
        private SqlCommand generarConsulta(string firstName, string lastName)
        {
            SqlCommand cmd = null;
            string query = "Select BusinessEntityID, FirstName, LastName from Person.Person where 1=1 ";

             if (firstName != "")
            {
                query += " and FirstName = @NAME";    
            }

             if(lastName != "")
            {
                query += " and LastName = @LNAME";
            }

            cmd = new SqlCommand(query, cn);
            cmd.Parameters.Add("@NAME", SqlDbType.NVarChar);
            cmd.Parameters["@NAME"].Value = firstName;
            cmd.Parameters.Add("@LNAME", SqlDbType.NVarChar);
            cmd.Parameters["@LNAME"].Value = lastName;

            return cmd;
        }
        */
    }
}
