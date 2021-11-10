using Perla_AP2_API_20190008.DAL;
using Perla_AP2_API_20190008.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Perla_AP2_API_20190008.BLL
{
    public class ProveedoresBLL
    {
        public static Proveedores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proveedores proveedores;
            try
            {
                proveedores = contexto.Proveedores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proveedores;
        }
        public static List<Proveedores> GetList(Expression<Func<Proveedores, bool>> criterio)
        {
            List<Proveedores> lista = new List<Proveedores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Proveedores.Where(criterio).ToList();
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
        public static List<Proveedores> GetList()
        {
            List<Proveedores> lista = new List<Proveedores>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Proveedores.ToList();
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
