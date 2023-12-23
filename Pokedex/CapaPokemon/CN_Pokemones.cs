using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocios
{
    public class CN_Pokemones
    {
        private CD_Pokemones objetoCD = new CD_Pokemones();

        public DataTable MostrarPokemon()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarPokemon (string nombre, string especie, string tipo, string habilidad, string peso, string altura, string grupo, string generacion)
        {
            objetoCD.Insertar(nombre, especie, tipo, habilidad, peso, altura, grupo, generacion);
        }

        public void EditarPokemon(string nombre, string especie, string tipo, string habilidad, string peso, string altura, string grupo, string generacion, string id)
        {
            objetoCD.Editar(nombre, especie, tipo, habilidad, peso, altura, grupo, generacion, Convert.ToInt32(id));
        }

        public void EliminarPokemon(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
