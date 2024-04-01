using Dumpify;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCars
{
    internal static class DumpExtensions
    {

        public static void DumpState<T>(this DbContext dbContext,T Entity) where T : class
        {
            var entry = dbContext.Entry(Entity);

            Console.WriteLine($"\n----- Entity States For {entry.Entity.GetType().Name} -----");

            Console.WriteLine($"EntityState: {Enum.GetName(entry.State)}\n");

            var states = entry.Properties
                                .Select(p => new
                                {
                                    Name = p.Metadata.Name,
                                    Value = p.CurrentValue,
                                    Modified = p.IsModified
                                });

            TableConfig tableConf = new TableConfig();
            tableConf.ShowTableHeaders = false;
            tableConf.ShowRowSeparators = true;

            TypeNamingConfig typeNamingConfig = new TypeNamingConfig();
            typeNamingConfig.SimplifyAnonymousObjectNames = true;
            
            TypeRenderingConfig renderingConfig = new TypeRenderingConfig();
            renderingConfig.QuoteStringValues = false;

            Console.WriteLine("Modifications:");
            foreach ( var state in states)
            {
                Console.WriteLine($"    {state.Name}: {state.Modified}");
            }

            Console.WriteLine();
                    
        }

    }
}
