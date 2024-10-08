﻿using System.Linq;
using SWZZPI_HFT_2023241.Models;

namespace SWZZPI_HFT_2023241.Repository
{
    public class ChampionsRepository : Repository<Champions>, IRepository<Champions>
    {
        public ChampionsRepository(LolDBContext ctx) : base(ctx)
        {
        }      
        public override Champions Read(int id)
        {
            return ctx.Champions.FirstOrDefault(t => t.Id == id);
        }
        public override void Update(Champions item)
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
