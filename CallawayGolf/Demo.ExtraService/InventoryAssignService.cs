using Demo.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ExtraService
{
    public class InventoryAssignService
    {
        private static InventoryAssignService m_singleton;

        private InventoryAssignService()
        {

        }

        public static InventoryAssignService Instance
        {
            get
            {
                if(m_singleton == null)
                {
                    m_singleton = new InventoryAssignService();
                }
                return m_singleton;
            }
        }

        [SuppressMessage("Microsoft.Design", "CS1998")]
        public async Task<bool> RandomAssignInventory(List<Product> products)
        {
            Parallel.ForEach<Product>(products, p =>
            {
                if (p != null)
                {
                    var random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
                    p.Inventory = random.Value.Next(1, 10);
                }
            });

            return true;
        }

    }
}
