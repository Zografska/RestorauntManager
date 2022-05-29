using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestaurantManager.Model;


namespace RestaurantManager.Services
{
    public class NoteService : BaseCrudService<Note>, INoteService
    {
        public NoteService()
        {
            Entities = new List<Note>
            {
                new Note { Title="Steve", Description="USA", LastModified = RandomDay()},
                new Note { Title="John", Description="USA", LastModified = RandomDay()},
                new Note { Title="Tom", Description="UK", LastModified = RandomDay()},
                new Note { Title="Lucas", Description="Germany", LastModified = RandomDay()},
                new Note { Title="Tariq", Description="UK", LastModified = RandomDay()},
                new Note { Title="Jane", Description="USA", LastModified = RandomDay()},
            };
        }

        public override bool Update(Note updatedEntity)
        {
            updatedEntity.LastModified = DateTime.Now;
            return base.Update(updatedEntity);
        }
    }
}