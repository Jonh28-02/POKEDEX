using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Pokemones
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //Procedimiento almacenado
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarPokemones";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string especie, string tipo, string habilidad, string peso, string altura, string grupo, string generacion)
        {
            //procedimiento almacenado
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarPokemones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@especie", especie);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@habilidad", habilidad);
            comando.Parameters.AddWithValue("@peso", peso);
            comando.Parameters.AddWithValue("@altura", altura);
            comando.Parameters.AddWithValue("@grupo", grupo);
            comando.Parameters.AddWithValue("@generacion", generacion);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Editar(string nombre, string especie, string tipo, string habilidad, string peso, string altura, string grupo, string generacion, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarPokemones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@especie", especie);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@habilidad", habilidad);
            comando.Parameters.AddWithValue("@peso", peso);
            comando.Parameters.AddWithValue("@altura", altura);
            comando.Parameters.AddWithValue("@grupo", grupo);
            comando.Parameters.AddWithValue("@generacion", generacion);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarPokemon";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idPokemon", id);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

    }
}
