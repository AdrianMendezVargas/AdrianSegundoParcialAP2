using AdrianSegundoParcialAP2.DAL;
using AdrianSegundoParcialAP2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdrianSegundoParcialAP2.BLL {
    public class VentasBLL {

        public async static Task<bool> Guardar(Venta venta) {
            if (!await Existe(venta.VentaId))
                return await Insertar(venta);
            else
                return await Modificar(venta);
        }

        public async static Task<bool> Insertar(Venta venta) {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {
                contexto.Ventas.Add(venta);
                paso = await contexto.SaveChangesAsync() > 0;
            } catch (Exception) {
                throw;
            } finally {
                await contexto.DisposeAsync();
            }

            return paso;
        }

        public async static Task<bool> Modificar(Venta venta) {
            bool paso = false;
            Contexto contexto = new Contexto();

            try {
                contexto.Entry(venta).State = EntityState.Modified;

                paso = await contexto.SaveChangesAsync() > 0;

            } catch (Exception) {

                throw;
            } finally {
                await contexto.DisposeAsync();
            }
            return paso;
        }

        public async static Task<bool> Eliminar(int id) {
            bool paso = false;
            Contexto contexto = new Contexto();
            try {
                var venta = contexto.Ventas.Find(id);

                if (venta != null) {
                    contexto.Ventas.Remove(venta);
                    paso = await contexto.SaveChangesAsync() > 0;
                }
            } catch (Exception) {
                throw;
            } finally {
                await contexto.DisposeAsync();
            }

            return paso;
        }

        public async static Task<Venta> Buscar(int id) {
            Contexto contexto = new Contexto();
            Venta venta;

            try {
                venta = await contexto.Ventas
                    .Where(v => v.VentaId == id)
                    .FirstOrDefaultAsync();
            } catch (Exception) {
                throw;
            } finally {
                await contexto.DisposeAsync();
            }

            return venta;
        }


        public async static Task<bool> Existe(int id) {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try {
                encontrado = await contexto.Ventas.AnyAsync(v => v.VentaId == id);
            } catch (Exception) {
                throw;
            } finally {
                await contexto.DisposeAsync();
            }

            return encontrado;
        }

        public async static Task<List<Venta>> GetVentas(int clienteId = 0) {
            Contexto contexto = new Contexto();

            List<Venta> ventas = new List<Venta>();
            await Task.Delay(01); //Para dar tiempo a renderizar el mensaje de carga

            try {
                if (clienteId > 0) {
                    ventas = (await contexto.Ventas.ToListAsync()).Where(v => v.ClienteId == clienteId && v.Balance > 0).ToList();
                } else {
                    ventas = await contexto.Ventas.ToListAsync();
                }

            } catch (Exception) {

                throw;
            } finally {
                await contexto.DisposeAsync();
            }

            return ventas;

        }

    }
}
