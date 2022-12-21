﻿using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {

        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Veri Oluşturma Tarihi");
            Property(x => x.ModifiedDate).HasColumnName("Veri Güncelleme Tarihi");
            Property(x => x.DeletedDate).HasColumnName("Veri Silme Tarihi");
            Property(x => x.Status).HasColumnName("Veri Durumu");
        }

    }
}
