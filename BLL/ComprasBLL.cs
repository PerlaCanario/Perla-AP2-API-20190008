using Microsoft.EntityFrameworkCore;
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
    public class ComprasBLL
    {
        public static bool Guardar(Compras compras)
        {
            if (!Existe(compras.ComprasId))
                return Insertar(compras);
            else
                return Modificar(compras);
        }

        private static bool Insertar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Compras.Add(compras);
                paso = contexto.SaveChanges() > 0;

                List<ComprasDetalle> detalle = compras.Detalle;
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

        private static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                List<ComprasDetalle> detalle = Buscar(compras.ComprasId).Detalle;

                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalle Where ComprasId={compras.ComprasId}");
                foreach (var item in compras.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                List<ComprasDetalle> nuevo = compras.Detalle;

                contexto.Entry(compras).State = EntityState.Modified;
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
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyecto = ComprasBLL.Buscar(id);
                List<ComprasDetalle> viejosDetalles = Buscar(proyecto.ComprasId).Detalle;

                if (proyecto != null)
                {
                    contexto.Entry(proyecto).State = EntityState.Deleted;
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
        public static Compras Buscar(int id)
        {
            Compras compras = new Compras();
            Contexto contexto = new Contexto();
            try
            {
                compras = contexto.Compras.Include(x => x.Detalle)
                    .Where(x => x.ComprasId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return compras;
        }

        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> Lista = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Compras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Compras.Any(e => e.ComprasId == id);
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
    }
}
