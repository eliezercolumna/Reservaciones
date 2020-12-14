using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Gestor_de_citas.DAO
{
    class visitanteDAO
    {
        private DataTable table = null;
        private MySqlConnection cn = null;
        private MySqlDataReader reader = null;
        private MySqlCommand cmd = null;
        

        private void Cerrar()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        public bool Insertar(string nombre, string apellido, string documento, string tipo_documento, string telefono, string tipo_telefono, string persona, string fecha)
        {
            try
            {
                cn = Conexion.conectar();
                cmd = cn.CreateCommand();
                cmd.CommandText = "INSERT INTO visitante (nombre, apellido, documento, tipo_documento, telefono, tipo_telefono, persona, fecha) values ('" + nombre + "','" + apellido + "','" + documento + "','" + tipo_documento + "','"+ telefono +"','"+ tipo_telefono + "','"+ persona + "','" + fecha+"'); ";
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                Cerrar();
            }
            return false;
        }
        //metodo para consultar
        public DataTable Consultar()
        {
            try
            {
                Columnas();
                cn = Conexion.conectar();
                cmd = cn.CreateCommand();
                cmd.CommandText = "select * from visitante";
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id_visitante = reader.GetInt32(0);
                    String nombre = reader.GetString(1);
                    String apellido = reader.GetString(2);
                    String documento = reader.GetString(3);
                    String tipo_documento = reader.GetString(4);
                    String telefono = reader.GetString(5);
                    String tipo_telefono = reader.GetString(6);
                    String Persona = reader.GetString(7);
                    String fecha = reader.GetString(8);
                    table.Rows.Add(id_visitante, nombre, apellido, documento, tipo_documento, telefono, tipo_telefono, Persona, fecha);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                Cerrar();
            }
            return table;
        }
        //metodo para eliminar
        public bool Eliminar(int id)
        {
            try
            {
                cn = Conexion.conectar();
                cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM visitante WHERE id_visitante=\"" + id + "\";";
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ocurrio un Error en el proceso");
            }
            finally
            {
                Cerrar();
            }
            return false;

        }
        //metodo para actualizar
        public bool Actualizar(int id, string nombre, string apellido, string documento, string tipo_documento, string telefono, string tipo_telefono, string persona, string text, string text1)
        {
            try
            {
                cn = Conexion.conectar();
                cmd = cn.CreateCommand();
                cmd.CommandText = "update visitante set nombre=\"" + nombre + "\",apellido=\"" + apellido + "\",documento=\"" + documento + "\",tipo_documento=\"" + tipo_documento + "\",telefono=\"" + telefono + "\",tipo_telefono=\"" + tipo_telefono + "\",persona=\"" + persona + "\",fecha=\"\" where id_visitante=\"" + id + "\";";
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ocurrion un Error en el proceso"); ;
            }
            finally
            {
                Cerrar();
            }
            return false;
        }

        private void Columnas()
        {
            table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Documento");
            table.Columns.Add("Tipo_doc");
            table.Columns.Add("telefono");
            table.Columns.Add("Tipo_tel");
            table.Columns.Add("Persona");
            table.Columns.Add("fecha");
        }
    }
}
