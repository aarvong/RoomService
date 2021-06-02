using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace RoomService.Class
{
    public class RoomServiceDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public RoomServiceDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(BookingData).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(BookingData)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<BookingData>> GetItemsAsync()
        {
            return Database.Table<BookingData>().ToListAsync();
        }

        public Task<List<BookingData>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<BookingData>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<BookingData> GetItemAsync(int id)
        {
            return Database.Table<BookingData>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(BookingData item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(BookingData item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
