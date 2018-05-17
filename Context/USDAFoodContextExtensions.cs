using System;

namespace USDAFoodDB.Context {
    public static class USDAFoodContextExtensions {
        public static USDAFoodContext BulkInsert<T>(this USDAFoodContext context, T entity, int count, int batchSize)
            where T : class {
            context.Set<T>().Add(entity);

            if (count % batchSize == 0) {
                context.SaveChanges();
                context.Dispose();
                context = new USDAFoodContext(context.DbContextOptions);
            }

            return context;
        }
    }
}
