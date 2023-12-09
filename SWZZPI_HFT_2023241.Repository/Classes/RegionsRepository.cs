using SWZZPI_HFT_2023241.Models;
using System.Linq;

namespace SWZZPI_HFT_2023241.Repository
{
    public class RegionsRepository : Repository<Regions>, IRepository<Regions>
    {
        public RegionsRepository(LolDBContext ctx) : base(ctx)
        {
        }
        public override Regions Read(int id)
        {
            return ctx.Regions.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Regions item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
