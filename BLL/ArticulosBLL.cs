﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Parcial1.DAL;
using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Controls;

namespace Parcial1.BLL
{
    public class ArticulosBLL
    {

        //Metodo Existe.
        public static bool Existe(int Id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Articulos.Any(encontrado => encontrado.ArticuloId == Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }


        //Metodo Insertar.
        private static bool Insertar(Entidades.Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Articulos.Add(articulos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        //Metodo Modificar.
        private static bool Modificar(Entidades.Articulos articulos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        //Metodo Guardar.
        public static bool Guardar(Entidades.Articulos articulos)
        {
            if (!Existe(articulos.ArticuloId))
                return Insertar(articulos);
            else
                return Modificar(articulos);
        }


        //Metodo Eliminar.
        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var articulos = contexto.Articulos.Find(Id);
                if(articulos != null)
                {
                    contexto.Articulos.Remove(articulos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        //Metodo Buscar.
        public static Entidades.Articulos Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Articulos articulos;

            try
            {
                articulos = contexto.Articulos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return articulos;
        }

        public static List<Entidades.Articulos> GetList(Expression<Func<Articulos, bool>> criterio)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Articulos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }



    }
}
