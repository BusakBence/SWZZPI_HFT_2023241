using SWZZPI_HFT_2023241.Models;
using System.Linq;

namespace SWZZPI_HFT_2023241.Repository
{
    public class AbilitiesRepository : Repository<Abilities>, IRepository<Abilities>
    {
        public AbilitiesRepository(LolDBContext ctx) : base(ctx)
        {
        }
        public override Abilities Read(int id)
        {
            return ctx.Abilities.FirstOrDefault(t => t.Id == id);
        }
        public override void Update(Abilities item)
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
