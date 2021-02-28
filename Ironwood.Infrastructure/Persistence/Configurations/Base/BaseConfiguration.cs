using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ironwood.Infrastructure.Persistence.Configurations.Base
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        private EntityTypeBuilder<T> _builder;

        public void Configure(EntityTypeBuilder<T> builder)
        {
            throw new NotImplementedException();
        }
        private void setDecimalPrecisions(EntityTypeBuilder<T> builder, int precision = 20, int scale = 8)
        {
            var _properties = typeof(T).GetProperties()
               .Where(p => p.PropertyType == typeof(decimal)
                        || p.PropertyType == typeof(decimal?))
               .Select(a => a.Name)
               .ToList();

            foreach (var _prop in _properties)
            {
                builder.Property(_prop).HasColumnType($"DECIMAL({precision},{scale})");
            }
        }

    }
}
