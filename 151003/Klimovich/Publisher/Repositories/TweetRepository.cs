﻿using Microsoft.EntityFrameworkCore;
using Publisher.Models;

namespace Publisher.Repositories
{
    public class TweetRepository : IRepository<Tweet>
    {
        private ApplicationContext _dbContext;

        public TweetRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Tweet Create(Tweet item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
            return item;
        }

        public int Delete(int id)
        {
            int res = _dbContext.Tweets.Where(n => n.id == id).ExecuteDelete();
            _dbContext.SaveChanges();
            return res;
        }

        public Tweet Get(int id)
        {
            var res = _dbContext.Tweets.Where(n => n.id == id).ToList();
            Tweet n;
            if (res.Count > 0)
            {
                n = res[0];
                return n;
            }
            else return null;
        }

        public List<Tweet> GetAll()
        {
            return _dbContext.Tweets.ToList();
        }

        public Tweet Update(Tweet item)
        {
            var res = _dbContext.Tweets.Where(n => n.id == item.id).ToList();
            Tweet n;
            if (res.Count > 0)
            {
                n = res[0];
            }
            else return null;
            if (item.userId != null)
            {
                n.userId = (int)item.userId;
            }
            if (item.title != null)
            {
                n.title = item.title;
            }
            if (item.content != null)
            {
                n.content = item.content;
            }
            n.modified = DateTime.UtcNow;
            _dbContext.Update(n);
            _dbContext.SaveChanges();
            return n;
        }
    }
}
