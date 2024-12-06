using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infractructure.Data;

public class InventarioManufacturadoContextSeed
{
    public static async Task SeedAsync(InventarioManufacturaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if(!context.TipoDeElaboraciones.Any())
            {
                var tiposDeElaboracionesData = File.ReadAllText("../Infractructure/Data/SeedData/TiposDeElaboraciones.json");

                var tiposDeElaboracion = JsonSerializer.Deserialize<List<TipoDeElaboracion>>(tiposDeElaboracionesData);

                foreach(var item in tiposDeElaboracion)
                {
                    context.TipoDeElaboraciones.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if(!context.Estados.Any())
            {
                var estadosData = File.ReadAllText("../Infractructure/Data/SeedData/Estados.json");

                var estados = JsonSerializer.Deserialize<List<Estado>>(estadosData);

                foreach(var item in estados)
                {
                    context.Estados.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if(!context.Productos.Any())
            {
                var productosData = File.ReadAllText("../Infractructure/Data/SeedData/Productos.json");

                var productos = JsonSerializer.Deserialize<List<Producto>>(productosData);

                foreach(var item in productos)
                {
                    context.Productos.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if(!context.EntradaMercancia.Any())
            {
                var entradaMercanciaData = File.ReadAllText("../Infractructure/Data/SeedData/EntradaMercancia.json");

                var entradaMercancia = JsonSerializer.Deserialize<List<EntradaMercancia>>(entradaMercanciaData);

                foreach(var item in entradaMercancia)
                {
                    context.EntradaMercancia.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if(!context.SalidaMercancia.Any())
            {
                var salidaMercanciaData = File.ReadAllText("../Infractructure/Data/SeedData/SalidaMercancia.json");

                var salidaMercancia = JsonSerializer.Deserialize<List<SalidaMercancia>>(salidaMercanciaData);

                foreach(var item in salidaMercancia)
                {
                    context.SalidaMercancia.Add(item);
                }

                await context.SaveChangesAsync();
            }

            if(!context.ProductosDefectuosos.Any())
            {
                var productosDefectuososData = File.ReadAllText("../Infractructure/Data/SeedData/ProductosDefectuosos.json");

                var productosDefectuosos = JsonSerializer.Deserialize<List<ProductosDefectuosos>>(productosDefectuososData);

                foreach(var item in productosDefectuosos)
                {
                    context.ProductosDefectuosos.Add(item);
                }

                await context.SaveChangesAsync();
            }
        }
        catch(Exception ex)
        {
            var logger = loggerFactory.CreateLogger<InventarioManufacturadoContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}