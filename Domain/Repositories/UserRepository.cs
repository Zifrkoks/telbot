using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using telbot.Domain.Database;
using telbot.Domain.Database.Models;

namespace telbot.Domain.Repositories
{
    public class UserRepository:IRepository<ChatUser>
    {
        private AppDbContext db;

        public UserRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(ChatUser obj)
        {
            try{
            await db.Users.AddAsync(obj);
            await db.SaveChangesAsync();
            }catch{
            return false;
            }
            return true;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await db.Users.FindAsync(id);
            if(obj == null)
            return false;
            try{
            db.Users.Remove(obj);
            await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<ChatUser?> ReadAsync(int id)
        {
            var obj = await db.Users.FindAsync(id);
            return obj;
        }
        public async Task<ChatUser?> ReadByChatAsync(long Chatid)
        {
            var obj = await db.Users.FirstOrDefaultAsync(u => u.ChatId == Chatid);
            return obj;
        }

        public async Task<bool> UpdateAsync(int id, ChatUser obj)
        {
            var olduser = await db.Users.FindAsync(id);
            if(obj == null || olduser == null)
            return false;
            try{
            obj.id = id;
            db.Users.Update(obj);
            await db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<List<ChatUser>> ReadAllAsync()
        {
            return await db.Users.ToListAsync();
        }
    }
}